using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabPatternSpawner : MonoBehaviour
{
    public PrefabPattern[] prefabPatterns;
    
    public int priority; // The spawn priority the object has (lower score is higher priority).
    public float chance; // The chance to spawn a prefab pattern (0.0 - 1.0).
    
    /// <summary>
    /// Tries to spawn a random prefab pattern from <c>prefabPatterns</c>.
    /// If the spawner actually returns a pattern depends on the <c>chance</c> to spawn an object.
    /// Resolving conflict between multiple spawners should be resolved by a
    /// <c>PrefabPatternSpawnerController</c> in combination with <c>priority</c>.
    /// </summary>
    /// <returns>A random prefab pattern or null</returns>
    [CanBeNull]
    public PrefabPattern AttemptSpawn()
    {
        float randChance = Random.value;
        if (chance >= randChance)
        {
            int randPattern = Random.Range(0, prefabPatterns.Length);
            return prefabPatterns[randPattern];
        }

        return null;
    }
}
