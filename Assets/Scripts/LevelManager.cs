using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    private int currentExp = 0;
    private int level = 1;
    private int requiredExp;

    public TextMeshProUGUI r_exp;
    public TextMeshProUGUI c_exp;
    public TextMeshProUGUI lvl;

    public GameObject skillUpPanel;
    private float lastIncTime;


    void Start()
    {
        hideSkillUp();
    }
    void FixedUpdate()
    {
        IncreaseExp();
        UpdateValues();
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
    void UpdateValues()
    {
        r_exp.text = requiredExp.ToString();
        c_exp.text = currentExp.ToString();
        lvl.text = level.ToString();

    }
    void IncreaseExp()
    {
        if (Time.time - lastIncTime >= 2)
        {
            currentExp += 100;
            lastIncTime = Time.time;
        }
    }
    void showSkillUp()
    {
        skillUpPanel.SetActive(true);
    }
    void hideSkillUp()
    {
        skillUpPanel.SetActive(false);
    }
}
