using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypointInd = 0;
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (waypointInd >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointInd++;
        target = Waypoints.points[waypointInd];
    }
}
