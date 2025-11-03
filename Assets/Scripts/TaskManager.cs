using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
[System.Serializable]
public class Task
{
    public int taskNmbr;
    public string description;
    public bool isComplete;
    public TMP_Text taskText;

}

public class TaskManager : MonoBehaviour
{
    private List<KelvinPlant> plants = new List<KelvinPlant>();
    private HashSet<string> uniquePlants = new HashSet<string>();

    [SerializeField] private int totalUniquePlants = 3;
    [SerializeField] private int totalPlants = 10;
    public static TaskManager Instance;

    public List<Task> tasks = new List<Task>();

    TreeGrowth tree;
    private bool stage1Grown = false;
    private bool stage2Grown = false;
    private bool stage5Grown = false;

    public EndSequenceController endController; // assign in Inspector
    private int currentStage = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        tree = GameObject.FindAnyObjectByType<TreeGrowth>();
        UpdateUI();
    }

    public void CompleteTask(int taskNumber)
    {
        foreach (var task in tasks)
        {
            if (task.taskNmbr == taskNumber && !task.isComplete)
            {
                task.isComplete = true;
                UpdateUI();
                return;
            }
        }
    }

    private void UpdateUI()
    {
        foreach (var task in tasks)
        {
            if (task.isComplete)
            {
                task.taskText.text = $"<s>{task.description}</s>";
            }
            else
            {
                task.taskText.text = task.description;
            }
        }
    }

    public void RegisterGrownPlant(KelvinPlant plant)
    {
        if (!plants.Contains(plant))
        {
            plants.Add(plant);
            uniquePlants.Add(plant.type);

            Check();
        }
    }

    public void Check()
    {
        if (uniquePlants.Count >= totalUniquePlants)
        {
            CompleteTask(2);
        }

        if(plants.Count >= totalPlants)
        {
            CompleteTask(5);
        }
    }
    //private void Update()
    //{
    //    if (IsTaskComplete(2))
    //    {
    //        bool completed = false;
    //        if (!completed)
    //        {
    //            completed = true;
    //            tree.Grow();
    //        }
    //    }

    //    if (IsTaskComplete(3))
    //    {
    //        bool completed = false;
    //        if (!completed)
    //        {
    //            completed = true;
    //            tree.Grow();
    //        }
    //    }

    //    if (IsTaskComplete(4))
    //    {
    //        bool completed = false;
    //        if (!completed)
    //        {
    //            completed = true;
    //            tree.Grow();
    //        }
    //    }
    //}

    private void Update()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
            endController.StartEndSequence();
       
        if (IsTaskComplete(1) && !stage1Grown)
        {
            tree.Grow();
            stage1Grown = true;
     
        }

       
        if (IsTaskComplete(2) && !stage2Grown)
        {
            tree.Grow();
            stage2Grown = true;
            
        }


        if (IsTaskComplete(5) && !stage5Grown)
        {
            tree.Grow();
            stage5Grown = true;
            Debug.Log("all task complete");
            endController.StartEndSequence();
        }
    }
    public bool IsTaskComplete(int taskNumber)
    {
        foreach (var task in tasks) // Go through all tasks
        {
            if (task.taskNmbr == taskNumber) // Check if it is the right task
            {
                return task.isComplete; // Return true if completed
            }
        }
        return false; // Otherwise return false
    }

}
