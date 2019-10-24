using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour {

    public GameObject goOk;
    public InputField playerName;
    public IdManager idManager;
    public GameObject goInstanciadorE, goInstanciadorD, goCountToStart, goCountToStartShadow, goPlayerName, goTimeManager, goTimeCount, goMusic;

    public void NewGame() {
        SceneManager.LoadScene ("Gameplay");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMenu() {
        SceneManager.LoadScene ("Menu");
    }

    public void LoadRecords() {
        SceneManager.LoadScene ("Top5");
    }

    public void LoadHowToPlay() {
        SceneManager.LoadScene ("HowToPlay");
    }

    public void ChekPlayerName() {
        if (playerName.text == "") {
            goOk.SetActive(false);
        } else {
            goOk.SetActive(true);
        }
    }

    public void StartGame() {
        idManager.SetPlayerName(playerName.text);
        goInstanciadorE.SetActive(true);
        goInstanciadorD.SetActive(true);
        goCountToStart.SetActive(true);
        goCountToStartShadow.SetActive(true);
        goTimeManager.SetActive(true);
        goTimeCount.SetActive(true);
        goPlayerName.SetActive(false);
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic() {

        yield return new WaitForSeconds(5);
        goMusic.GetComponent<AudioSource>().Play();

    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
