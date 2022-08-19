using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Search : MonoBehaviour
{
    [SerializeField]
    private GameObject warning;
    [SerializeField]
    private GameObject input;
    private TMP_InputField inputField;
    private DataManager dataManager;
    private HandleOutput handleOutput;
    public UnityEvent OnSetActive = new UnityEvent();

    private void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        inputField = input.GetComponent<TMP_InputField>();
        handleOutput = FindObjectOfType<HandleOutput>();
        dataManager = FindObjectOfType<DataManager>();
    }

    public void SearchButton()
    {
        string dataText = inputField.text;
        inputField.text = "";
        OnSetActive?.Invoke();
        if (!IsValidNumber(dataText))
        {
            warning.SetActive(true);
            return;
        }
        warning.SetActive(false);
        //find and show result
        int number = int.Parse(dataText);
        Ticket ticket = new Ticket(number, 0);
        int indexInList = LogState.FindIndex(ticket);
        if (indexInList == -1)
        {
            warning.SetActive(true);
            return;
        }
        int money = LogState.tickets[indexInList].money;
        if (money == 0) Debug.Log("Not found");
        else Debug.Log("Found");
        if (money == 0) return;
        handleOutput.InitNumberData(number, money);

    }

    private bool IsValidNumber(string text)
    {
        if (text.Length > 2) return false;
        for (int i = 0; i < text.Length; i++)
        {
            if (!char.IsDigit(text[i])) return false;
        }
        return true;
    }
}
