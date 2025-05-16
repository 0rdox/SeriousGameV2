using UnityEngine;

[CreateAssetMenu(fileName = "ServiceLocatorConfig", menuName = "ScriptableObjects/ServiceLocator", order = 1)]
public class ServiceLocator : ScriptableObject
{
    public GameManager gameManager;
    public DataStorageManager dataStorageManager;

    public GameManager GetGameManager() => gameManager;

    public DataStorageManager GetDataStorageManager() => dataStorageManager;

}

