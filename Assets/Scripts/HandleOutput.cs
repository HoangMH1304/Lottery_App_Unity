using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HandleOutput : MonoBehaviour
{
    [SerializeField]
    private GameObject result;
    [SerializeField]
    private Transform parent;
    private TMP_InputField textField;
    private GenerateButton generateButton;
    private List<Ticket> numMoney = new List<Ticket>();

    private void Start()
    {
        generateButton = FindObjectOfType<GenerateButton>();
        generateButton.OnCall.AddListener(SmallestToLargestNum);
    }
    public void SmallestToLargestNum()
    {
        for (int i = 0; i < 100; i++)
        {
            int money = LogState.totalMoneyInNumber[i];
            if (money != 0) InitNumberData(i, money);
        }
    }

    public void LargestToSmallestNum()
    {
        for (int i = 99; i >= 0; i--)
        {
            int money = LogState.totalMoneyInNumber[i];
            if (money != 0) InitNumberData(i, money);
        }
    }

    public void SmallestToLargestMoney()
    {
        InitList();
        numMoney.Sort(SortByMoney);
        MultiPrint();
    }

    public void LargestToSmallestMoney()
    {
        InitList();
        numMoney.Sort(SortByMoney);
        numMoney.Reverse();
        MultiPrint();
    }

    private static int SortByMoney(Ticket p1, Ticket p2)
    {
        return p1.money.CompareTo(p2.money);
    }

    private void MultiPrint()
    {
        for (int i = 0; i < numMoney.Count; i++)
        {
            int number = numMoney[i].number;
            int money = numMoney[i].money;
            InitNumberData(number, money);
        }
        numMoney.Clear();
    }

    private void InitList()
    {
        for (int i = 0; i < 100; i++)
        {
            int money = LogState.totalMoneyInNumber[i];
            Ticket player = new Ticket();
            player.number = i;
            player.money = money;
            if (money != 0) numMoney.Add(player);
        }
    }

    public void InitNumberData(int index, int money)
    {
        var userData = Instantiate(result);
        userData.transform.SetParent(parent);
        var data = userData.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        data.text = index.ToString() + ": " + money.ToString();
    }
}