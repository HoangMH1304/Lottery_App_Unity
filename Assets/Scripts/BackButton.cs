using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void Back()
    {
        DestroyUI("Out");
        var handleActiveState = FindObjectOfType<HandleActiveState>();
        handleActiveState.MultiSetActiveState();
        DestroyUI("Inp");
        LogState.ResetValue();
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
