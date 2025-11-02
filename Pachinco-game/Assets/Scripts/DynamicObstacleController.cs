using UnityEngine;

public class DynamicObstacleController : MonoBehaviour
{
    public enum MovementDirection { Horizontal, Vertical }
    [SerializeField] private MovementDirection movementDirection = MovementDirection.Horizontal;

    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float movementRange = 2.0f;

    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float rotationSpeed = 90f;

    private Vector3 startPosition;
    private bool movingForward = true;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        float delta = moveSpeed * Time.deltaTime;

        if (movementDirection == MovementDirection.Horizontal)
        {
            if (movingForward)
            {
                position.x += delta;
            }
            else
            {
                position.x -= delta;
            }

            float offset = position.x - startPosition.x;

            if (Mathf.Abs(offset) >= movementRange)
            {
                // Clamp position exactly within the movement range
                position.x = startPosition.x + Mathf.Sign(offset) * movementRange;
                movingForward = !movingForward;
            }
        }
        else // Vertical movement
        {
            if (movingForward)
            {
                position.y += delta;
            }
            else
            {
                position.y -= delta;
            }

            float offset = position.y - startPosition.y;

            if (Mathf.Abs(offset) >= movementRange)
            {
                position.y = startPosition.y + Mathf.Sign(offset) * movementRange;
                movingForward = !movingForward;
            }
        }

        transform.position = position;

        // Add rotation
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}


