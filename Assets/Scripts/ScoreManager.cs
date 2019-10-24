using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int gameScore = 0;
    
    public Text txtGameScore, txtGameScoreShadow, txtScoreRecord;

    public int GetGameScore() {
        return gameScore;
    }

    public void SetGameScore(int score) {
        gameScore = score;
    }

    public void SetGameScoreText() {
        txtGameScore.text = GetGameScore().ToString();
        txtGameScoreShadow.text = txtGameScore.text;
    }

    public void AddGameScore(int value) {
        int newScore;
        newScore = GetGameScore() + value;
        SetGameScore(newScore);
    }

    public void MinusGameScore() {
        int newScore = (GetGameScore()-2);
        SetGameScore(newScore);
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }
}