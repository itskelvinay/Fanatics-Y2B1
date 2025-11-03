//using UnityEngine;

//public class FlowerCounter : MonoBehaviour
//{
//    [SerializeField] private TreeGrowth treeGrowth;
//    [SerializeField] private int flowerThreshold = 5;
//    [SerializeField] private int taskNumberToComplete = 3;
//    private bool finalStageTriggered = false;

//    void Start()
//    {
//        if (treeGrowth == null)
//            treeGrowth = FindAnyObjectByType<TreeGrowth>();
//    }
        
//    void Update()
//    {
//        if (finalStageTriggered) return;

//        KelvinPlant[] allFlowers = FindObjectsOfType<KelvinPlant>();
//        int totalFlowers = allFlowers.Length;

//        if (totalFlowers >= flowerThreshold)
//        {
//            Debug.Log($"Flower threshold reached: {totalFlowers}");

//            // Ask the tree to grow its final stage
//            treeGrowth.RevealFinalStage();

//            if (TaskManager.Instance != null)
//                TaskManager.Instance.CompleteTask(taskNumberToComplete);

//            finalStageTriggered = true;
//        }
//    }
//}
