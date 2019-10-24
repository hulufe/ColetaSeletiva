using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdManager : MonoBehaviour
{
    public Text trashName;
    public Text playerName;

    public void SetTrashName(string name) {
        trashName.text = name;
    }

    public string GetTrashName() {
        return trashName.text;
    }

    public void SetPlayerName(string name) {
        playerName.text = name;
    }

    public string GetPlayerName() {
        return playerName.text;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
