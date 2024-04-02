using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text endScreen;
    bool isTransitioning = false;

    void Start()
    {
        scoreText.text = "Start";
        endScreen.enabled = false;
    }
    
    public void IncreaseScore(int amountToIncrease)
    {
        if (isTransitioning) return;
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }

    public void CrashInfo()
    {
        scoreText.text = "Error";
        isTransitioning = true;
    }

    public void EndScreen()
    {
        endScreen.text = $"Mission accomplished/nYour score: {score}";
        scoreText.enabled = false;
        endScreen.enabled = true;
    }
}
