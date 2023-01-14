using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextFieldFeatures : MonoBehaviour
{
    [SerializeField]
    private GameObject warning;
    [SerializeField]
    private GameObject textField;
    [SerializeField]
    private GameObject userData;
    private TMP_InputField inputField;
    private DataManager dataManager;
    private AddUser addUser;
    private DataContainer dataContainer;
    private List<Ticket> numberMoney = new List<Ticket>();
    private string temp;
    private void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        inputField = textField.GetComponent<TMP_InputField>();
        dataManager = FindObjectOfType<DataManager>();
        dataContainer = GetComponent<DataContainer>();
    }

    // 12: 3 -> 12: 2 => -1?
    public void AdjustData()
    {
        if (!dataManager.IsValidText(inputField.text)) return;
        temp = inputField.text;
        numberMoney = dataManager.StringToList(inputField.text);
        // DeleteData();
    }

    public void Apply()     //need modify x2
    {
        Debug.Log("Deselect");
        if (dataManager.IsValidText(inputField.text))
        {
            if (temp == inputField.text) return;
            dataManager.Sum(inputField.text);
            inputField.text = dataManager.GetCorrectFormString();
            TurnOffActiveState();
        }
        else
        {
            warning.SetActive(true);
        }
        DeleteData();
    }

    private void DeleteData()
    {
        for (int i = 0; i < numberMoney.Count; i++)
        {
            int indexInList = LogState.FindIndex(numberMoney[i]);
            LogState.tickets[indexInList].money -= numberMoney[i].money;
        }
        numberMoney.Clear();
    }

    public void Delete()
    {
        AdjustData();
        DeleteData();
        Destroy(userData);
        TurnOffActiveState();
    }

    private void TurnOffActiveState()
    {
        warning.SetActive(false);
    }
}