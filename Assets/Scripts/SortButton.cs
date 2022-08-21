using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SortButton : MonoBehaviour
{
    public UnityEvent OnDeath = new UnityEvent();
    private HandleOutput handleOutput;

    private void Start()
    {
        GetReference();
    }

    private void GetReference()
    {
        handleOutput = FindObjectOfType<HandleOutput>();
    }

    enum SortOptions
    {
        SmallestToLargest_Num,
        LargestToSmallest_Num,
        SmallestToLargest_Money,
        LargestToSmallest_Money
    }
    public void Sort(int value)
    {
        OnDeath?.Invoke();
        switch (value)
        {
            case (int)SortOptions.SmallestToLargest_Num:
                handleOutput.SmallestToLargestNum();
                break;
            case (int)SortOptions.LargestToSmallest_Num:
                handleOutput.LargestToSmallestNum();
                break;
            case (int)SortOptions.SmallestToLargest_Money:
                handleOutput.SmallestToLargestMoney();
                break;
            case (int)SortOptions.LargestToSmallest_Money:
                handleOutput.LargestToSmallestMoney();
                break;
        }
    }
}
