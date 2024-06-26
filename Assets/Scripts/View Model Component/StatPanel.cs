using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatPanel : MonoBehaviour
{
    public Panel panel;
    public Sprite allyBackground;
    public Sprite enemyBackground;
    public Image background;
    public Image avatar;
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI hpLabel;
    public TextMeshProUGUI mpLabel;
    public TextMeshProUGUI lvLabel;

    public void Display(GameObject obj)
    {
        Alliance alliance = obj.GetComponent<Alliance>();
        background.sprite = alliance.type == Alliances.Enemy ? enemyBackground : allyBackground;
        // avatar.sprite = null; Need a component which provides this data
        nameLabel.text = obj.name;
        Stats stats = obj.GetComponent<Stats>();
        if (stats)
        {
            hpLabel.text = string.Format("HP {0} / {1}", stats[StatTypes.HP], stats[StatTypes.MHP]);
            mpLabel.text = string.Format("MP {0} / {1}", stats[StatTypes.MP], stats[StatTypes.MMP]);
            lvLabel.text = string.Format("LV. {0}", stats[StatTypes.LVL]);
        }
    }
}
