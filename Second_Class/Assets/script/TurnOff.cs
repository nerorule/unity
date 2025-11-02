using UnityEngine;

public class TurnOff : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }
}
