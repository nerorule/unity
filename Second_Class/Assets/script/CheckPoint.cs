using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject activeState = null;
    [SerializeField]
    private GameObject inActiveState = null;

    private bool isActive = false;

    private void Awake()
    {
        SetActiveState(false);
    }
    public void SetActiveState(bool active)
    {
        isActive = active;
        activeState.SetActive(active);
        inActiveState.SetActive(!active);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isActive)
        {
            return;
        }
        if (collision != null && collision.GetComponent<PlayerController>())
        {
            SetActiveState(true);
            GameController.Instance.SetLastCheckPoint(this);
        }
    }
}
