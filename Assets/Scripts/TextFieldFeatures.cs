using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextFieldFeatures : MonoBehaviour
{
    [SerializeField]
    private GameObject applyButton;
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
        Debug.Log("Select");
        if (!dataManager.IsValidText(inputField.text, false)) return;
        numberMoney = dataManager.StringToList2(inputField.text);
    }

    public void Apply()     //need modify
    {
        Debug.Log("Deselect");
        if (dataManager.IsValidText(inputField.text, true))
        {
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
        // AdjustData();
        for (int i = 0; i < numberMoney.Count; i++)
        {
            // LogState.totalMoneyInNumber[(int)numberMoney[i].x] -= (int)numberMoney[i].y;
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
        applyButton.SetActive(false);
        warning.SetActive(false);
    }
}