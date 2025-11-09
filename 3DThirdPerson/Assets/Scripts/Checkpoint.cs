using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if it's the player
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            // Tell the player to update their checkpoint
            player.SetCheckpoint(transform.position);
            Debug.Log("Checkpoint activated at " + transform.position);
        }
    }
}
