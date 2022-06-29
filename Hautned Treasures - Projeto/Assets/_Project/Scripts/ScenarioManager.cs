using _Project.Scripts.Exorcism;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public ExorcismCollections exorcismItemsCollection;
    public ItemSpawnersManager itemSpawnersManager;

    private void Start()
    {
        itemSpawnersManager.SpawnItemsAtRandom(exorcismItemsCollection.AllItems());
    }
}