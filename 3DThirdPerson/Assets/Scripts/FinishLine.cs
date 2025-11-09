using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] 
    private GameTimer timer; 

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            timer.StopTimer();
            Debug.Log("Done and Dusted!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
