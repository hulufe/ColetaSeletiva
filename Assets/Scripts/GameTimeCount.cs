using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeCount : MonoBehaviour
{
    public TimeManager timeManager;
    public GameObject goGameMusic;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(ControlGameTime());
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator ControlGameTime() {

        while (timeManager.GetGameTime() > 0) {

            yield return new WaitForSeconds(1);
            
            timeManager.SetGameTime(timeManager.GetGameTime() - 1);

            if (timeManager.GetGameTime() < 15) {
                goGameMusic.GetComponent<AudioSource>().pitch = 1.125f;
            } else {
                goGameMusic.GetComponent<AudioSource>().pitch = 1f;
            }
            
            if (timeManager.GetGameTime() < 0) {
                timeManager.SetGameTime(0);
            }

            timeManager.SetGameTimeText();

            // Debug.Log("Fim do Jogo? " + timeManager.EndGame().ToString());

            if (timeManager.EndGame()) { 

                timeManager.SetGameOver();
                
            }
            // Debug.Log(timeManager.GetGameTime().ToString());
            
        }

    }

}
