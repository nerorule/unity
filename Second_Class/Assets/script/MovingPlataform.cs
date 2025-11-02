using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;

    private Vector3 targetPosition;

    private void Start()
    {
        if (pointA != null && pointB != null)
        {
            targetPosition = pointB.position;
        }
    }

    private void Update()
    {
        if (pointA == null || pointB == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Switch directions when close to the target
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            targetPosition = (targetPosition == pointA.position) ? pointB.position : pointA.position;
        }
    }
}

