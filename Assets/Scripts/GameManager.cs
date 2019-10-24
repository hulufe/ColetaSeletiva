using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject lixeira;

    public ScoreManager scoreManager;
    public TimeManager timeManager;
    public BonusManager bonusManager;
    public RecordsManager recordsManager;

    public AudioClip sndError;
    public AudioClip sndMatch;
    public AudioClip sndBonus;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerEnter2D (Collider2D coll) {
        
        AudioSource audio = GetComponent<AudioSource>();

        if (coll.gameObject.tag == lixeira.gameObject.tag) {

            scoreManager.AddGameScore(10);
            audio.clip = sndMatch;
            audio.Play();

            if (scoreManager.GetGameScore() >= bonusManager.GetScoreBonusTarget()) {
                timeManager.AddGameTime();
                bonusManager.AddScoreBonusTarget();
                audio.clip = sndBonus;
                audio.Play();
            }

        } else {
            
            timeManager.LossGameTime(5);
            audio.clip = sndError;
            audio.Play();

        }

        scoreManager.SetGameScoreText();

        Destroy(coll.gameObject);
    }
}