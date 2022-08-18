using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string standardizedText;
    public List<Vector2> keyvalues = new List<Vector2>();

    public bool IsValidText(string text, bool calculate)
    {
        standardizedText = "";
        if (text == "") return false;
        string[] multinumbers = text.Split(';');
        for (int i = 0; i < multinumbers.Length; i++)
        {
            string[] data = SplitUserData(multinumbers, i);
            if (data[0].Length > 2 || data.Length != 2) return false;
            if (!IsIntegerNumber(data[0]) || !IsIntegerNumber(data[1])) return false;
            StandardizedData(multinumbers, i, data);
            if (calculate == true) Calculate(data);
        }
        return true;
    }

    public List<Vector2> StringToList(string text)
    {
        List<Vector2> numberAndMoney = new List<Vector2>();
        string[] multinumbers = text.Split(';');
        for (int i = 0; i < multinumbers.Length; i++)
        {
            string[] data = SplitUserData(multinumbers, i);
            int num = int.Parse(data[0]);
            int money = int.Parse(data[1]);
            numberAndMoney.Add(new Vector2(num, money));
        }
        return numberAndMoney;
    }

    private void Calculate(string[] data)
    {
        int num = int.Parse(data[0]);
        int money = int.Parse(data[1]);
        LogState.totalMoneyInNumber[num] += money;
    }

    public void Reset()
    {
        keyvalues.Clear();
    }

    private static string[] SplitUserData(string[] multinumbers, int i)
    {
        char[] separators = new char[] { ' ', ':' };
        string[] data = multinumbers[i].Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        return data;
    }

    private void StandardizedData(string[] multinumbers, int i, string[] data)
    {
        standardizedText += (data[0] + ": " + data[1]);
        if (i != multinumbers.Length - 1) standardizedText += "; ";
    }

    public string GetCorrectFormString()
    {
        return standardizedText;
    }

    private bool IsIntegerNumber(string num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            if (!char.IsDigit(num[i])) return false;
        }
        return true;
    }
}