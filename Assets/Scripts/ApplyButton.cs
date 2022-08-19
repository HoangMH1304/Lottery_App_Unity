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

    // 12: 3 -> 12: 2 => -1?
    public void AdjustData()
    {
        Debug.Log("Select");
        if (!dataManager.IsValidText(inputField.text, false)) return;
        numberMoney = dataManager.StringToList(inputField.text);
        // applyButton.SetActive(true);
    }

    public void Apply()
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
            LogState.totalMoneyInNumber[(int)numberMoney[i].x] -= (int)numberMoney[i].y;
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