using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleActiveState : MonoBehaviour
{
    [SerializeField]
    private GameObject[] GameObjects;
    private GenerateButton generate;
    void Start()
    {
        generate = FindObjectOfType<GenerateButton>();
        generate.OnCall.AddListener(MultiSetActiveState);
    }

    public void MultiSetActiveState()
    {
        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].activeSelf == true)
                GameObjects[i].SetActive(false);
            else
                GameObjects[i].SetActive(true);
        }
    }
}
