using System;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    public GameObject[] stages; // assign 3 cubes
    private int currentStage = 0;


    void Start()
    {
        for (int i = 0; i < stages.Length; i++)
            stages[i].SetActive(false);

        SetStage(0);
    }

    public void Grow()
    {
        if (currentStage < stages.Length - 1)
        {
            currentStage++;
            SetStage(currentStage);

        }
    }

    void SetStage(int index)
    {
        stages[index].SetActive(true);
    }
}
