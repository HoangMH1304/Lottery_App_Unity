using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    private List<Vector2> keyvalues = new List<Vector2>();

    private DataManager dataManager;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
    }

    public void SetLists(List<Vector2> numberMoney)
    {
        // Debug.Log($"List Size2: {DataManager.GetDataList().Count}");
        keyvalues = numberMoney;
        // DataManager.keyvalues.Clear();
        Debug.Log($"List Size: {keyvalues.Count}");

    }
}
