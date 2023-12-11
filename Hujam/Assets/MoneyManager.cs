using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int startMoney = 10000;
    public TextMeshProUGUI textMeshProUGUI;
    private void Awake()
    {
        PlayerStats.money = startMoney;
    }

    private void Update()
    {
        textMeshProUGUI.text = "$" + PlayerStats.money;
    }
}
