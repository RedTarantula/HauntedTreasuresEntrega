using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Exorcism;
using ECM.Components;
using ECM.Examples;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class PlayerInfos : MonoBehaviour
{
    public EndGameCanvas endGameCanvas;
    public PlaythroughGhostsManaged ghostsManager;
    public FPS_CustomController fpsController;
    public Transform _transformHand;
    public TMP_Text _textInfo;

    public ExorcismItem itemInHands;
    public GameObject itemInHandsInstance;

    [SerializeField] private GameObject _lastExorcismItem;
    [SerializeField] private float itemDistancePickup = 2f;

    [SerializeField] private KeyCode _takeItem = KeyCode.F;

    [SerializeField] private bool isInDeliverZone;

    public MMFeedbacks deathFeedback;
    private bool isOver;

    private void Start()
    {
        isOver = false;
    }

    private void Update()
    {
        if (isOver)
        {
            return;
        }
        
        if (Input.GetKeyDown(_takeItem))
        {
            if (_lastExorcismItem != null)
            {
                float dist = Vector3.Distance(_transformHand.position, _lastExorcismItem.transform.position);
                Debug.Log($"Distance to object: {dist}, {_lastExorcismItem.name}");
                ExorcismItemInstance comp = _lastExorcismItem.GetComponent<ExorcismItemInstance>();

                if (dist <= itemDistancePickup && comp != null)
                {
                    PickUpItem(comp.item, _lastExorcismItem);
                }
                else
                {
                    DropItem();
                }
            }
            else
            {
                DropItem();
            }
        }
    }

    public void PickUpItem(ExorcismItem item, GameObject go)
    {
        if (itemInHandsInstance != null)
        {
            DropItem();
            return;
        }

        itemInHands = item;
        itemInHandsInstance = Instantiate(item.itemPrefab, _transformHand);
        itemInHandsInstance.transform.localScale = Vector3.one;
        itemInHandsInstance.transform.localPosition = Vector3.zero;
        itemInHandsInstance.transform.localRotation = item.rotationInHands;

        fpsController.moveSpeedPenaltyCarrying = 0.5f;
    }

    public void DropItem()
    {
        fpsController.moveSpeedPenaltyCarrying = 0f;
        if (itemInHands == null) return;

        if (isInDeliverZone)
        {
            ghostsManager.AttemptDeliver(itemInHands);
        }
        
        Destroy(itemInHandsInstance);
        itemInHands = null;
    }

    public void SetLastItemOnFocus(GameObject item)
    {
        _lastExorcismItem = item;
        //ExorcismItemInstance exorcismItem = obj.GetComponent<ExorcismItemInstance>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isOver)
        {
            return;
        }
        
        Collider collisionCollider = collision.collider;
        if (collisionCollider.CompareTag("Visible"))
        {
            if (collisionCollider.name == "Zombie")
            {
                Die();
            }
        }
    }

    private void Die()
    {
        endGameCanvas.GameFinished(false);
        deathFeedback.PlayFeedbacks();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeliverZone"))
        {
            isInDeliverZone = true;
            ghostsManager.EnterCircle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DeliverZone"))
        {
            isInDeliverZone = false;
            ghostsManager.ExitCircle();
        }
    }

    public void GameOver()
    {
        isOver = true;
    }
}