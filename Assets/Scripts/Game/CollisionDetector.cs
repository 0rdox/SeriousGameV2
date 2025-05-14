using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    public UnityEvent<GameObject> collisionEvent;
    public string[] colliderTag;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (colliderTag.Any(c => other.gameObject.tag.Equals(c)))
        {
            collisionEvent.Invoke(other.gameObject);
        }
    }
}
