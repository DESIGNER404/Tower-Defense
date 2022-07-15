using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    public int Gold, TowerCost, EnemyCost, Lives;
    public TextMeshProUGUI LivesTxt, GoldTxt;

    void Start()
    {
        GoldTxt.text = "Gold: " + Gold;
    }

    public void MissEnemy()
    {
        Lives--;
        LivesTxt.text = "Lives: " + Lives;
        if (Lives <= 0)
        {

        }
    }

    public void Build()
    {
        Gold -= TowerCost;
        GoldTxt.text = "Gold: " + Gold;
    }

    public void Kill()
    {
        Gold += EnemyCost;
        GoldTxt.text = "Gold: " + Gold;
    }
}
