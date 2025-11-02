using UnityEngine;

public class BallController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if it's a Slot
        if (collision.CompareTag("Slot"))
        {
            // Try to get a Slot component and read its point value
            Slot slot = collision.GetComponent<Slot>();
            if (slot != null)
            {
                GameManager.Instance.AddToScore(slot.pointValue);
            }

            Destroy(gameObject); // Destroy the ball when it reaches a slot
        }

        // Check if it's a Pickup
        else if (collision.CompareTag("Pickup"))
        {
            Pickup pickup = collision.GetComponent<Pickup>();
            if (pickup != null)
            {
                GameManager.Instance.AddToScore(pickup.pointValue);
                Destroy(pickup.gameObject); // Remove the pickup
            }
        }
    }
}
