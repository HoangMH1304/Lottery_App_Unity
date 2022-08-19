using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    private SortButton sortButton;
    private Search search;
    private void Start()
    {
        GetReference();
        sortButton.OnDeath.AddListener(DestroyMySelf);
        search.OnSetActive.AddListener(TurnOffMySelf);
    }

    private void GetReference()
    {
        sortButton = FindObjectOfType<SortButton>();
        search = FindObjectOfType<Search>();
    }

    private void DestroyMySelf()
    {
        Destroy(gameObject);
    }

    private void TurnOffMySelf()
    {
        gameObject.SetActive(false);
    }
}
