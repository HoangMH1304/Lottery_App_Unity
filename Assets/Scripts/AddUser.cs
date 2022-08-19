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
    [SerializeField]
    private GameObject warning;
    private TMP_InputField inputText;
    private DataManager dataManager;

    private void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        inputText = input.GetComponent<TMP_InputField>();
        dataManager = FindObjectOfType<DataManager>();
    }

    public void GetUser()
    {
        string data = inputText.text;
        inputText.text = "";
        if (!dataManager.IsValidText(data, true))
        {
            warning.SetActive(true);
            return;
        }
        warning.SetActive(false);
        InitUserData();
    }

    private void InitUserData()
    {
        var userData = Instantiate(output);
        userData.transform.SetParent(parent);
        string data = dataManager.GetCorrectFormString();
        userData.transform.Find("User").GetComponent<TMP_InputField>().text = data;
        // dataManager.Reset();
    }
}