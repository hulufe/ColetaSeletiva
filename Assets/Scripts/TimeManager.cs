using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float gameTime = 65;
    private float gameTimeBonus = 5;
    public Text txtGameTime, txtGameTimeShadow, txtPlayerName;
    public GameObject goInstanciadorE, goInstanciadorD, goGameOver, goRecordsManager, goTimeCount, goMusic, goGameOverMusic, goGameOverMusicRecord, goNewRecord;
    public RecordsManager recordsManager;
    public ScoreManager scoreManager;
    
    public float GetGameTime() {
        return gameTime;
    }

    public void SetGameTimeText() {

        // Debug.Log("Tempo: " + GetGameTime().ToString("0"));

        txtGameTime.text = GetGameTime().ToString("0");
        txtGameTimeShadow.text = txtGameTime.text;
        
        if (GetGameTime() <= 15) {
            txtGameTime.color = Color.red;
        } else {
            txtGameTime.color = Color.white;
        }

    }

    public void SetGameTime (float time) {
        gameTime = time;
    }

    public void AddGameTime() {
        SetGameTime(GetGameTime() + gameTimeBonus);
    }

    public void LossGameTime(float minusTime) {
        SetGameTime(GetGameTime() - minusTime);
    }

    public bool EndGame() {
        if (GetGameTime() <= 0) return true;
        return false;
    }

    public void SetGameOver() {
        
        // desativa os instanciadores de lixo
        goInstanciadorD.SetActive(false);
        goInstanciadorE.SetActive(false);
        goTimeCount.SetActive(false);
        goMusic.GetComponent<AudioSource>().Stop();
        

        // exibe a mensagem de Fim de Jogo
        goGameOver.SetActive(true);

        
        // destroi todos os lixos que ficaram na tela
        foreach (GameObject lixo in GameObject.FindGameObjectsWithTag("Metal")) { Destroy(lixo); }
        foreach (GameObject lixo in GameObject.FindGameObjectsWithTag("Plastic")) { Destroy(lixo); }
        foreach (GameObject lixo in GameObject.FindGameObjectsWithTag("Glass")) { Destroy(lixo); }
        foreach (GameObject lixo in GameObject.FindGameObjectsWithTag("Paper")) { Destroy(lixo); }
        foreach (GameObject lixo in GameObject.FindGameObjectsWithTag("Organic")) { Destroy(lixo); }

        // define os Recordes de pontuação
        recordsManager.SetRecords(txtPlayerName.text, scoreManager.GetGameScore());


        Debug.Log("GAME OVER! Pontos: " + scoreManager.GetGameScore().ToString());
        Debug.Log("GAME OVER! Recorde: " + recordsManager.txtPontos.text);

        if  (scoreManager.GetGameScore() > int.Parse(recordsManager.txtPontos.text)) {
            goGameOverMusicRecord.GetComponent<AudioSource>().Play();
            // exibe a mensagem de Novo Recorde
            goNewRecord.SetActive(true);
            Debug.Log("NOVO RECORDE!");
        } else {
            goGameOverMusic.GetComponent<AudioSource>().Play();
            Debug.Log("NÃO BATEU O RECORDE!");
        }
        
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        

    }

}