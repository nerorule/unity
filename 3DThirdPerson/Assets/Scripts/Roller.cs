using UnityEngine;

public class Roller : MonoBehaviour
{
    [SerializeField]
    public float rotationSpeed = 90f; // degrees per second

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
