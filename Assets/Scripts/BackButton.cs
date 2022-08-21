using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;
    public void Back()
    {
        dropdown.value = 0;
        DestroyUI("Out");
        var handleActiveState = FindObjectOfType<HandleActiveState>();
        handleActiveState.MultiSetActiveState();
        // DestroyUI("Inp");
        // LogState.ResetValue();
    }

    public static void DestroyUI(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject temp in gameObjects)
        {
            Destroy(temp);
        }
    }
}
