using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabPattern", menuName = "ScriptableObjects/PrefabPattern", order = 1)]
public class PrefabPattern : ScriptableObject
{
    [CanBeNull] public GameObject object0;
    [CanBeNull] public GameObject object1;
    [CanBeNull] public GameObject object2;
}
