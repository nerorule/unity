using UnityEngine;

public class ActivateOnPlayerEnter : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (objectToActivate != null)
       {
          objectToActivate.SetActive(true);
       }
    }
}

