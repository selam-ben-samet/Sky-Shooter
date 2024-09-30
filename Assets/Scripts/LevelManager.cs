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
    float shipHealthRegen;
    float shipResistance;
    float shipAttackSpeed;
    float shipAttackDamage;

    public TextMeshProUGUI UIshipMaxHealth;
    public TextMeshProUGUI UIshipHealthRegen;
    public TextMeshProUGUI UIshipResistance;
    public TextMeshProUGUI UIshipAttackSpeed;
    public TextMeshProUGUI UIshipAttackDamage;
    public Image experienceOrb;


    public GameObject UpgradePanel;
    private float lastIncTime;


    void Start()
    {

        ship = GameObject.Find("Ship");
        hideSkillUp();
        healthOrb.fillAmount = 1;
        experienceOrb.fillAmount = 0;
        UpdateStats();
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

        healthOrb.fillAmount = shipHealth / shipMaxHealth;

        // experience




        experienceOrb.fillAmount = currentExp / requiredExp;






    }
    public void UpdateStats()
    {
        shipMaxHealth = ship.GetComponent<ShipController>().maxHealth;
        shipHealthRegen = ship.GetComponent<ShipController>().healthRegen;
        shipResistance = ship.GetComponent<ShipController>().resistance;
        shipAttackSpeed = ship.GetComponent<ShipController>().attackSpeed;
        shipAttackDamage = ship.GetComponent<ShipController>().attackDamage;

        UIshipMaxHealth.text = shipMaxHealth.ToString();
        UIshipHealthRegen.text = shipHealthRegen.ToString();
        UIshipResistance.text = shipResistance.ToString();
        UIshipAttackSpeed.text = shipAttackSpeed.ToString();
        UIshipAttackDamage.text = shipAttackDamage.ToString();
    }
    public void IncreaseExp(int value)
    {
        currentExp += value;
    }
    void showSkillUp()
    {
        Time.timeScale = 0;
        UpgradePanel.SetActive(true);
    }
    void hideSkillUp()
    {

        UpgradePanel.SetActive(false);
    }
    public int GetLevel()
    {
        return level;
    }
}
