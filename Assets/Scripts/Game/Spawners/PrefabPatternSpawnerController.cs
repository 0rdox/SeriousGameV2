using System.Collections.Generic;
using UnityEngine;

public class PrefabPatternSpawnerController : MonoBehaviour
{
    public float timeBetweenSpawn; // The time between spawns in seconds.
    private float _timeSinceLastSpawn; // The time since the last spawn in seconds.

    public Transform container; // The container where prefabs are spawned.
    private List<PrefabPatternSpawner> _childSpawners;
    
    private void Start()
    {
        _timeSinceLastSpawn = timeBetweenSpawn;

        // Get all child prefab spawners
        _childSpawners = new List<PrefabPatternSpawner>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _childSpawners.Add(transform.GetChild(i).GetComponent<PrefabPatternSpawner>());
        }
    }

    /// <summary>
    /// Executed every frame, It will check if the spawners will have to spawn new patterns again,
    /// based on the <c>timeBetweenSpawns</c>.
    /// When it is time to spawn new patterns, the <c>PrefabPatternSpawners</c> will be requested to spawn a new pattern.
    /// Eventual conflicts between multiple spawners will be resolved based on their priority (see <see cref="PrefabPatternSpawner"/>).
    /// </summary>
    private void Update()
    {
        // Execute when enough time has passed.
        if (_timeSinceLastSpawn >= timeBetweenSpawn)
        {
            // Get patterns from all child spawners.
            var patternsToSpawn = new List<(int, PrefabPattern)>();
            _childSpawners.ForEach(spawner =>
            {
                var prefab = spawner.AttemptSpawn(); 
                if (prefab) patternsToSpawn.Add((spawner.priority, prefab)); 
            });
            
            // Try to spawn all the patterns.
            SpawnPatterns(patternsToSpawn);
            
            _timeSinceLastSpawn = 0;
        }

        _timeSinceLastSpawn += Time.deltaTime;
    }
    
    /// <summary>
    /// Spawns the patterns based on the priority given to them.
    /// Patterns with a higher priority (lower number) will be the ones spawned when multiple
    /// patterns at the same spot are being given.
    /// </summary>
    /// <param name="patterns">A tuple with an integer <c>priority</c> and a PrefabPattern <c>pattern</c></param>
    private void SpawnPatterns(List<(int priority, PrefabPattern pattern)> patterns)
    {
        var positions = new GameObject[] {null, null, null};
        
        // Fill empty positions where patterns with higher priority go first.
        patterns.Sort((a, b) => a.priority.CompareTo(b.priority));
        patterns.ForEach(pattern =>
        {
            if (!positions[0]) positions[0] = pattern.pattern.object0;
            if (!positions[1]) positions[1] = pattern.pattern.object1;
            if (!positions[2]) positions[2] = pattern.pattern.object2;
        });
        
        // Spawn the all objects in positions.
        if (positions[0])
            Instantiate(positions[0], new Vector3(transform.position.x - 2, transform.position.y), Quaternion.identity, container);
        if (positions[1])
            Instantiate(positions[1], new Vector3(transform.position.x, transform.position.y), Quaternion.identity, container);
        if (positions[2])
            Instantiate(positions[2], new Vector3(transform.position.x + 2, transform.position.y), Quaternion.identity, container);
    }
}
