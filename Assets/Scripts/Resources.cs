using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public int Gold, TowerCost, EnemyCost, Lives;
    public TextMeshProUGUI LivesTxt, GoldTxt;
    public GameObject DeathPanel, ResourcesPanel;

    public Button SpeedBtn;
    private int _enemyKilled;

    void Start()
    {
        Time.timeScale = 1;
        DeathPanel.SetActive(false);
        GoldTxt.text = "Gold: " + Gold;
        LivesTxt.text = "Lives" + Lives;
    }

    public void MissEnemy()
    {
        Lives--;
        LivesTxt.text = "Lives: " + Lives;
        if (Lives <= 0)
        {
            Time.timeScale = 0;
            ResourcesPanel.SetActive(true);
            DeathPanel.SetActive(true);
        }
    }

    public void ChangeSpeed()
    {
        if(Time.timeScale == 0.5)
        {
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 2;
        }
        else if (Time.timeScale == 2)
        {
            Time.timeScale = 5;
        }
        else if (Time.timeScale == 5)
        {
            Time.timeScale = 0.5f;
        }

        SpeedBtn.GetComponentInChildren<TextMeshProUGUI>().text = Time.timeScale + "x";
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        _enemyKilled++;
    }
}
