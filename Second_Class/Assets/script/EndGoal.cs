using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    [SerializeField]
    private bool reloadCurrent = true;

    private bool player1Present = false;
    private bool player2Present = false;
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponentInParent<PlayerController>();
        if (player == null)
        {
            return;
        }

        if (player.IsPlayer1)
        {
            player1Present = true;
        }
        else
        {
            player2Present = true;
        }

        TryActivate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponentInParent<PlayerController>();
        if (player == null)
        {
            return;
        }

        if (player.IsPlayer1)
        {
            player1Present = false;
        }
        else
        {
            player2Present = false;
        }
    }

    private void TryActivate()
    {
        if (activated)
        {
            return;
        }

        if (player1Present && player2Present)
        {
            activated = true;
            if (reloadCurrent)
            {
                ReloadCurrentScene();
            }
            else
            {
                GoToNextScene();
            }
        }
    }

    private void ReloadCurrentScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    private void GoToNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        int nextScene = (index + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }
}


