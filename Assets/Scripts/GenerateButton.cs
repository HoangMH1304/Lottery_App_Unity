using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class GenerateButton : MonoBehaviour
{
    [SerializeField]
    private GameObject textFieldGameObject;
    [SerializeField]
    private GameObject contentArea;
    [SerializeField]
    private GameObject result;
    [SerializeField]
    private GameObject warning;
    [SerializeField]
    private Transform parent;
    private TMP_InputField textField;
    public UnityEvent OnCall = new UnityEvent();

    private void Start()
    {
        textField = textFieldGameObject.GetComponent<TMP_InputField>();
        OnCall.AddListener(InitOutput);
    }

    public void GenerateData()
    {
        if (textField.text == "" && contentArea.activeSelf == true)
        {
            OnCall?.Invoke();
            warning.SetActive(false);
        }
        else
        {
            warning.SetActive(true);
        }
    }

    private void InitOutput()
    {
        for (int i = 0; i < 100; i++)
        {
            int money = LogState.totalMoneyInNumber[i];
            if (money != 0)
            {
                InitNumberData(i, money);
                Debug.Log($"{i}: {money}");
            }
        }
    }

    private void InitNumberData(int index, int money)
    {
        var userData = Instantiate(result);
        userData.transform.SetParent(parent);
        var data = userData.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        data.text = index.ToString() + ": " + money.ToString();
    }
}
