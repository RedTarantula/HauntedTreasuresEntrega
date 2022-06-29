using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Exorcism
{
    public class PlaythroughGhostsManaged : MonoBehaviour
    {
        public ExorcismCollections exorcismCollections;
        public GhostGeneration GhostGeneration = new GhostGeneration();
        public List<PassiveGhost> passiveGhosts;
        public EndGameCanvas endGameCanvas;

        public TMP_Text hint1;

        public bool deliveredBelonging;
        public bool deliveredElemental;

        [Range(1, 3)] public int ghostsToSpawn;
        
        private int ghostId;

        public MMFeedbacks openHints;
        public MMFeedbacks closeHints;
        public MMFeedbacks rightDeliver;
        public MMFeedbacks wrongDeliver;

        public void EnterCircle()
        {
            openHints.PlayFeedbacks();
        }

        public void ExitCircle()
        {
            closeHints.PlayFeedbacks();
        }
        
        public void Start()
        {
            RandomizeGhosts();
            ghostId = 0;
            SetupNewGhost();
        }

        private void SetupNewGhost()
        {
            if (ghostId < passiveGhosts.Count)
            {
                hint1.text = passiveGhosts[ghostId].HintsBelonging;
                deliveredBelonging = false;
                deliveredElemental = false;
            }
            else
            {
                endGameCanvas.GameFinished(true);
            }
        }

        [Button("Randomize Ghosts")]
        public void RandomizeGhosts()
        {
            List<ExorcismItem> belongings = new List<ExorcismItem>(exorcismCollections.belongings);
            belongings.ShuffleList();
            Queue<ExorcismItem> belongingsQueue = new Queue<ExorcismItem>(belongings);

            List<ExorcismItem> elementals = new List<ExorcismItem>(exorcismCollections.elementals);
            elementals.ShuffleList();
            Queue<ExorcismItem> elementalsQueue = new Queue<ExorcismItem>(elementals);

            passiveGhosts = GhostGeneration.GenerateGhosts(ghostsToSpawn);

            foreach (PassiveGhost ghost in passiveGhosts)
            {
                ghost.ghostExorcism.requiredBelonging = belongingsQueue.Dequeue();
                ghost.HintsBelonging = ghost.ghostExorcism.requiredBelonging.RandomHints(3);

                ghost.ghostExorcism.requiredElemental = elementalsQueue.Dequeue();
                ghost.HintsElemental = ghost.ghostExorcism.requiredElemental.RandomHints(2);

            }
        }

        public void AttemptDeliver(ExorcismItem itemInHands)
        {
            bool deliveringBelonging = itemInHands == passiveGhosts[0].ghostExorcism.requiredBelonging;
            bool deliveringElemental = itemInHands == passiveGhosts[0].ghostExorcism.requiredElemental;

            if (deliveringBelonging && !deliveredBelonging)
            {
                deliveredBelonging = true;
                hint1.text = passiveGhosts[ghostId].HintsElemental;
                rightDeliver.PlayFeedbacks();
                return;
            }

            if (deliveringElemental && !deliveredElemental && deliveredBelonging)
            {
                deliveredElemental = true;
                hint1.text = "";
                rightDeliver.PlayFeedbacks();
                ghostId++;
                SetupNewGhost();
                return;
            }
            
            wrongDeliver.PlayFeedbacks();
        }
    }
}