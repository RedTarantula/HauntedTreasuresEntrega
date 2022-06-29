using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Exorcism;
using UnityEngine;

public class ItemSpawnersManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public Transform spawnedItemsParent;

    public void SpawnItemsAtRandom(List<ExorcismItem> items)
    {
        spawnPoints.ShuffleList();

        for (int i = 0, j = 0; i < items.Count; i++, j++)
        {
            ExorcismItem item = items[i];
            Transform spawnPoint = spawnPoints[j];

            GameObject itemInstance = Instantiate(item.itemPrefab);
            itemInstance.transform.position = spawnPoint.position;
            itemInstance.transform.parent = spawnedItemsParent;
            
            ExorcismItemInstance instComponent = itemInstance.GetComponent<ExorcismItemInstance>();
            instComponent.item = item;
            instComponent.itemType = item.itemType;
            
            if (j >= spawnPoints.Count - 1)
            {
                j = 0;
            }
        }
    }
    
}
