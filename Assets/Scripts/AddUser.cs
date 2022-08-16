using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddUser : MonoBehaviour
{
    [SerializeField]
    private GameObject input;
    [SerializeField]
    private GameObject output;
    [SerializeField]
    private Transform parent;
    private TMP_InputField inputText;
    private TMP_InputField outputText;
    private int[] numberValue = new int[100];
    private string standardizedText;

    private void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        inputText = input.GetComponent<TMP_InputField>();
        // outputText = output.transform.Find("User").GetComponent<TMP_InputField>();
    }

    public void GetUser()
    {
        string data = inputText.text;
        // Debug.Log(data);
        inputText.text = "";
        if (!ValidText(data)) return;
        // outputText.text = standardizedText;
        InitUserData();
        // userData.GetComponent<TMP_InputField>().text = data;
    }

    private void InitUserData()
    {
        var userData = Instantiate(output);
        userData.transform.SetParent(parent);
        userData.transform.Find("User").GetComponent<TMP_InputField>().text = standardizedText;
    }

    private bool ValidText(string text)
    {
        standardizedText = "";
        if (text == "") return false;
        string[] multinumbers = text.Split(';');
        for (int i = 0; i < multinumbers.Length; i++)
        {
            // Debug.Log(multinumbers[i]);
            // Debug.Log("\n");
            string[] data = SplitUserData(multinumbers, i);
            // for (int j = 0; j < data.Length; j++)
            // {
            //     Debug.Log(data[j]);
            // }
            if (data.Length != 2) return false;
            if (!IsIntegerNumber(data[0]) || !IsIntegerNumber(data[1])) return false;
            StandardizedData(multinumbers, i, data);
            // numberValue[int.Parse(data[0])] += float.Parse(data[1]);
            // Debug.Log(float.Parse(data[1]));
            // Debug.Log($"numberValue[{int.Parse(data[0])}] = {float.Parse(data[1])}");
        }
        return true;
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

    private bool IsIntegerNumber(string num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            if (!char.IsDigit(num[i])) return false;
        }
        return true;
    }

    // private bool IsRealNumber(string num)
    // {
    //     int numComma = 0;
    //     if (num[0] == ',' || num[num.Length - 1] == ',') return false;
    //     for (int i = 0; i < num.Length; i++)
    //     {
    //         if (!char.IsDigit(num[i]) && num[i] != ',') return false;
    //         if (num[i] == ',') numComma++;
    //     }
    //     return numComma <= 1;
    // }
}