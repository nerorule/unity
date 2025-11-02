using UnityEngine;

public class Killz : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            GameController.Instance.KillPlayer(player);
        }
    }
}

