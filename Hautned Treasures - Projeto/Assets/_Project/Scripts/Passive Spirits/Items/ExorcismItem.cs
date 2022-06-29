using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Exorcism
{
    [Serializable]
    public class ExorcismItem
    {
        public string itemName;
        public GameObject itemPrefab;
        //public GameObject handPrefab;
        public string[] possibleHints;
        public ItemInstanceType itemType;
        public float movementPenalty = .2f;
        public Quaternion rotationInHands;

        public string RandomHints(int quantity)
        {
            List<string> hintsList = new List<string>(possibleHints);
             hintsList.ShuffleList();
             Queue<string> hintsQueue = new Queue<string>(hintsList);

             string hints = "";
             for (int i = 1; i < quantity; i++)
             {
                 hints += hintsQueue.Dequeue() + ";\n\n";   
             }
             hints += hintsQueue.Dequeue() + ".";
             
            return hints;
        }
    }
}