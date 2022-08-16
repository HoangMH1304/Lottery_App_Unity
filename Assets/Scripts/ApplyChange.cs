using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyChange : MonoBehaviour
{
    [SerializeField]
    private GameObject applyButton;

    public void ShowApplyButton()
    {
        applyButton.SetActive(true);
    }

    public void Apply()
    {
        applyButton.SetActive(false);
    }
}
