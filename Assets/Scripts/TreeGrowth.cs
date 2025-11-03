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


//public void RevealFinalStage()
//{
//    // Only reveal the final stage if the tree has reached stage 2 first
//    if (currentStage >= stages.Length - 2)
//    {
//        currentStage = stages.Length - 1;
//        SetStage(currentStage);
//        Debug.Log("Final tree stage revealed!");
//    }
//    else
//    {
//        Debug.Log("Final stage skipped: tree not ready yet.");
//    }
//}


}
