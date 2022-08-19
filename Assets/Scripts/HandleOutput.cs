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
    [SerializeField]
    private TMP_Dropdown dropdown;
    private TMP_InputField textField;
    private GenerateButton generateButton;
    private List<Ticket> numMoney = new List<Ticket>();

    private void Start()
    {
        generateButton = FindObjectOfType<GenerateButton>();
        // generateButton.OnCall.AddListener(SortOrder);
        generateButton.OnCall.AddListener(SmallestToLargestNum);
    }

    private void SortOrder()
    {
        dropdown.value = 0;
    }
    private static int SortByMoney(Ticket p1, Ticket p2)
    {
        return p1.money.CompareTo(p2.money);
    }

    private static int SortByNumber(Ticket t1, Ticket t2)
    {
        return t1.number.CompareTo(t2.number);
    }

    public void SmallestToLargestNum()
    {
        // InitList();
        // numMoney.Sort(SortByNumber);
        LogState.tickets.Sort(SortByNumber);
        MultiPrint();
    }

    public void LargestToSmallestNum()
    {
        // InitList();
        // numMoney.Sort(SortByNumber);
        // numMoney.Reverse();
        LogState.tickets.Sort(SortByNumber);
        LogState.tickets.Reverse();
        MultiPrint();
    }

    public void SmallestToLargestMoney()
    {
        // InitList();
        // numMoney.Sort(SortByNumber);
        LogState.tickets.Sort(SortByMoney);
        MultiPrint();
    }

    public void LargestToSmallestMoney()
    {
        // InitList();
        // numMoney.Sort(SortByNumber);
        // numMoney.Reverse();
        LogState.tickets.Sort(SortByMoney);
        LogState.tickets.Reverse();
        MultiPrint();
    }

    private void MultiPrint()
    {
        for (int i = 0; i < LogState.tickets.Count; i++)
        {
            int number = LogState.tickets[i].number;
            int money = LogState.tickets[i].money;
            // int number = numMoney[i].number;
            // int money = numMoney[i].money;
            InitNumberData(number, money);
        }
        numMoney.Clear();
    }

    // private void InitList()
    // {
    //     // numMoney = LogState.tickets;

    //     // for (int i = 0; i < 100; i++)
    //     // {
    //     //     int money = LogState.totalMoneyInNumber[i];
    //     //     Ticket player = new Ticket();
    //     //     player.number = i;
    //     //     player.money = money;
    //     //     if (money != 0) numMoney.Add(player);
    //     // }
    // }

    public void InitNumberData(int index, int money)
    {
        if (money == 0) return;
        var userData = Instantiate(result);
        userData.transform.SetParent(parent);
        var data = userData.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        data.text = index.ToString() + ": " + money.ToString();
    }
}