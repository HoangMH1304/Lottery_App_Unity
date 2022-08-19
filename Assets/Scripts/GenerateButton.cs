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
    private GameObject warning;
    private TMP_InputField textField;
    public UnityEvent OnCall = new UnityEvent();

    private void Start()
    {
        textField = textFieldGameObject.GetComponent<TMP_InputField>();
    }

    public void GenerateData()
    {
        GameObject[] warnings = GameObject.FindGameObjectsWithTag("Warning");
        if (warnings.Length == 0 && textField.text == "")
        {
            OnCall?.Invoke();
            warning.SetActive(false);
        }
        else if (textField.text != "")
        {
            warning.SetActive(true);
        }
    }
}