using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationController : MonoBehaviour
{
    [SerializeField] ConversationPanel leftPanel;
    [SerializeField] ConversationPanel rightPanel;
    Canvas canvas;
    IEnumerator conversation;
    Tweener transition;

    const string ShowTop = "Show Top";
    const string ShowBottom = "Show Bottom";
    const string HideTop = "Hide Top";
    const string HideBottom = "Hide Bottom";

    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        if (leftPanel.panel.CurrentPosition == null)
            leftPanel.panel.SetPosition(HideBottom, false);
        if (rightPanel.panel.CurrentPosition == null)
            rightPanel.panel.SetPosition(HideBottom, false);
        canvas.gameObject.SetActive(false);
    }

    public static event EventHandler completeEvent;

    public void Show(ConversationData data)
    {
        canvas.gameObject.SetActive(true);
        conversation = Sequence(data);
        conversation.MoveNext();
    }

    public void Next()
    {
        if (conversation == null || transition != null)
            return;

        conversation.MoveNext();
    }

    IEnumerator Sequence(ConversationData data)
    {
        for (int i = 0; i < data.list.Count; ++i)
        {
            SpeakerData sd = data.list[i];

            ConversationPanel currentPanel = (sd.anchor == TextAnchor.UpperLeft || sd.anchor == TextAnchor.MiddleLeft || sd.anchor == TextAnchor.LowerLeft) ? leftPanel : rightPanel;
            IEnumerator presenter = currentPanel.Display(sd);
            // Show first line of sd
            presenter.MoveNext();

            string show, hide;
            if (sd.anchor == TextAnchor.UpperLeft || sd.anchor == TextAnchor.UpperCenter || sd.anchor == TextAnchor.UpperRight)
            {
                show = ShowTop;
                hide = HideTop;
            }
            else
            {
                show = ShowBottom;
                hide = HideBottom;
            }

            currentPanel.panel.SetPosition(hide, false);
            MovePanel(currentPanel, show);

            yield return null;
            while (presenter.MoveNext())
                yield return null;

            MovePanel(currentPanel, hide);
            transition.completedEvent += delegate (object sender, EventArgs e)
            {
                conversation.MoveNext();
            };

            yield return null;
        }

        canvas.gameObject.SetActive(false);
        if (completeEvent != null)
            completeEvent(this, EventArgs.Empty);
    }

    void MovePanel(ConversationPanel obj, string pos)
    {
        transition = obj.panel.SetPosition(pos, true);
        transition.duration = 0.5f;
        transition.equation = EasingEquations.EaseOutQuad;
    }
}
