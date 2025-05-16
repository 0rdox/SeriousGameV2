using UnityEngine;

public class PointConnector : MonoBehaviour
{
    //Next game object in path
    public GameObject nextPoint;

    //prefab that connects the paths
    public GameObject connectorPrefab;

    //Parent for instantaties connector
    public GameObject parent;

    void Start() {
        var connector = Instantiate(connectorPrefab, parent.transform);
        this.Connect(transform, nextPoint.transform, connector.transform);
    }

    private void Connect(Transform circleA, Transform circleB, Transform connector) {
        //Get middel pont of the two circles
        Vector3 midPoint = (circleA.position + circleB.position) / 2f;
        connector.position = midPoint;

        //Set Scale of connector
        float distance = Vector3.Distance(circleA.position, circleB.position);
        Vector3 newScale = connector.localScale;
        newScale.x = distance;
        connector.localScale = newScale;

        //set rotate of connector
        Vector3 direction = circleB.position - circleA.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        connector.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
