using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI timerText;   
    [SerializeField] 
    private TextMeshProUGUI resultText;
    private float elapsedTime = 0f;
    private bool isRunning = true;

    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;
        if (resultText != null)
        {
            resultText.text = "";
        }
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StopTimer()
    {
        isRunning = false;
        ShowFinalTime();
    }

    void ShowFinalTime()
    {
        if (resultText == null)
        {
            return;
        }

        string remark = "";
        if (elapsedTime < 30f)
        {
            remark = "Gotta go Fast!";
        }
        else if (elapsedTime < 60f)
        {
            remark = "Wanna se me do it again?";
        }
        else if (elapsedTime < 120f)
        {
            remark = "Im speed!";
        }
        else
        {
            remark = "Its cap!";
        }

        resultText.text = $"Final Time: {timerText.text}\n{remark}";
    }
}
