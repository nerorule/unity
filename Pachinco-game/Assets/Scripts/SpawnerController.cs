using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float moveSpeed = 5f;

    // Range the spawner is allowed to move
    [SerializeField] private float horizontalRange = 3f;
    [SerializeField] private float verticalRange = 1.5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 position = transform.position;

        // Handle input for movement (WASD or Arrow Keys)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            position.x += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            position.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            position.y -= moveSpeed * Time.deltaTime;
        }

        // Clamp position within a movement range based on initial position
        float xOffset = Mathf.Clamp(position.x - startPosition.x, -horizontalRange, horizontalRange);
        float yOffset = Mathf.Clamp(position.y - startPosition.y, -verticalRange, verticalRange);

        position = new Vector3(startPosition.x + xOffset, startPosition.y + yOffset, position.z);

        transform.position = position;

        // Spawn ball on spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Quaternion.identity means no rotation
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }
}
