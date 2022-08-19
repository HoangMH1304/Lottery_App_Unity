using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ApplyButton : MonoBehaviour
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
    private List<Vector2> numberMoney = new List<Vector2>();

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

    public void ShowApplyButton()
    {
        if (!dataManager.IsValidText(inputField.text, false)) return;
        numberMoney = dataManager.StringToList(inputField.text);
        // for (int i = 0; i < numberMoney.Count; i++)
        // {
        //     LogState.totalMoneyInNumber[(int)numberMoney[i].x] -= (int)numberMoney[i].y;
        // }
        // applyButton.SetActive(true);  //modify
    }

    public void Apply()
    {
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
        for (int i = 0; i < numberMoney.Count; i++)
        {
            LogState.totalMoneyInNumber[(int)numberMoney[i].x] -= (int)numberMoney[i].y;
        }
    }

    public void Delete()
    {
        Destroy(userData);
        TurnOffActiveState();
        DeleteData();
    }

    private void TurnOffActiveState()
    {
        applyButton.SetActive(false);
        warning.SetActive(false);
    }
}