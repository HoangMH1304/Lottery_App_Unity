using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string standardizedText;
    // public List<Vector2> keyvalues = new List<Vector2>();

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
            if (int.Parse(data[1]) == 0) return false;
            StandardizedData(multinumbers, i, data);
            if (calculate == true) Calculate(data);
        }
        return true;
    }

    public List<Ticket> StringToList2(string text)
    {
        List<Ticket> tickets = new List<Ticket>();
        string[] multinumbers = text.Split(';');
        for (int i = 0; i < multinumbers.Length; i++)
        {
            string[] data = SplitUserData(multinumbers, i);
            int num = int.Parse(data[0]);
            int money = int.Parse(data[1]);
            Ticket ticket = new Ticket(num, money);
            tickets.Add(ticket);
        }
        return tickets;
    }

    private void Calculate(string[] data)
    {
        int num = int.Parse(data[0]);
        int money = int.Parse(data[1]);
        Ticket ticket = new Ticket(num, money);
        int index = LogState.FindIndex(ticket);
        if (index != -1)
        {
            LogState.tickets[index].money += money;
        }
        else
        {
            LogState.tickets.Add(ticket);
        }
    }

    // public void Reset()
    // {
    //     keyvalues.Clear();
    // }

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