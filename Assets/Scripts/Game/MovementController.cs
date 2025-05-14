using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed;
    
    private void Update()
    {
        var currentPosition = transform.position;

        transform.position = new Vector3(currentPosition.x, currentPosition.y - 1 * speed * Time.deltaTime);
    }
}
