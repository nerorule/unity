using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController = null;
    private Vector3 lastCheckPointPosition = Vector3.zero;

    static private GameController instance = null;

    static public GameController Instance { get { return instance;} }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Initialize();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Initialize()
    {
      lastCheckPointPosition = playerController.transform.position;
    }
    public void SetLastCheckPoint(CheckPoint checkPoint)
    {
        lastCheckPointPosition = checkPoint.transform.position;
    }
    public void KillPlayer(PlayerController player)
    {
        player.transform.position = lastCheckPointPosition;
    }

}
