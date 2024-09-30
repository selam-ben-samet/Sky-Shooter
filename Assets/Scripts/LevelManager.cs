using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float currentExp = 0;
    private int level = 1;
    private float requiredExp;

    private GameObject ship;
    public Image healthOrb;
    float shipHealth;
    float shipMaxHealth;
    public Image experienceOrb;


    public GameObject skillUpPanel;
    private float lastIncTime;


    void Start()
    {
        ship = GameObject.Find("Ship");
        hideSkillUp();
        healthOrb.fillAmount = 1;
        experienceOrb.fillAmount = 0;
    }
    void Update()
    {
        UpdatePanel();
    }
    void FixedUpdate()
    {


        if (currentExp > requiredExp)
        {
            CheckLevelUp();
        }
        CalculateRequiredExp();
    }
    void CalculateRequiredExp()
    {
        requiredExp = (int)(Math.Pow(1.3d, level) * 100.0d);
    }
    void CheckLevelUp()
    {

        level++;
        showSkillUp();
        currentExp = 0;


    }
    void UpdatePanel()
    {

        // health
        shipHealth = ship.GetComponent<ShipController>().health;
        shipMaxHealth = ship.GetComponent<ShipController>().maxHealth;
        healthOrb.fillAmount = shipHealth / shipMaxHealth;

        // experience


        Debug.Log("currentexp" + currentExp + "\n" + "requiredexp" + requiredExp);

        experienceOrb.fillAmount = currentExp / requiredExp;
        Debug.Log("experience icin sonuc: " + (currentExp / requiredExp));




    }
    public void IncreaseExp(int value)
    {
        currentExp += value;
    }
    void showSkillUp()
    {
        skillUpPanel.SetActive(true);
    }
    void hideSkillUp()
    {
        skillUpPanel.SetActive(false);
    }
    public int GetLevel()
    {
        return level;
    }
}
