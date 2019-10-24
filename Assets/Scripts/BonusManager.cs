using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    private int gameScoreBonusTarget = 100;
    private int gameScoreBonusTargetAdd = 100;

    public int GetScoreBonusTarget() {
        return gameScoreBonusTarget;
    }

    public int GetScoreBonusTargetAdd() {
        return gameScoreBonusTargetAdd;
    }

    public void AddScoreBonusTarget() {
        gameScoreBonusTarget += gameScoreBonusTargetAdd;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
