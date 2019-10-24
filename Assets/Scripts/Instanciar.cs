using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instanciar : MonoBehaviour {
    
    public float minSpawnTime;
    public float maxSpawnTime;
    public float spawnItem;

    public ScoreManager scoreManager; 
    
    public GameObject[] Itens;
    private GameObject item;
    private int index;
    private float variacaoForca;
    
    public float upForce = 400f;
    public float sideForce = 200f;
    public float minX, maxX; // Posição do instanciador

    public GameObject goCount;
    public Text txtCount, txtCountShadow;

    private int count = 3;

    private void StartGame() {

        StartCoroutine( CountDown() );

    }
    
    // Start is called before the first frame update
    void Start() {  

        minX = CamManager.MinX();
        maxX = CamManager.MaxX();
        StartGame();

    }

    // Update is called once per frame
    void Update() {
        
    }

    bool RandomItem() {
        if (Itens.Length > 0) {
            index = Random.Range(0, Itens.Length);
            return true;
        }
        return false;
    }

    private IEnumerator Instanciador() {

        spawnItem = Random.Range (minSpawnTime, maxSpawnTime);
        spawnItem = spawnItem - (spawnItem * scoreManager.GetGameScore() / 1000);

        yield return new WaitForSeconds(spawnItem);

        if (RandomItem()) {

            variacaoForca = Random.Range(1, 5);

            item = Instantiate(Itens[index], new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, Random.Range(-60, 60))) as GameObject;          

            if (transform.position.x < 0) {
                item.GetComponent<Rigidbody2D>().AddForce(new Vector2(sideForce * variacaoForca, upForce));
            } else {
                item.GetComponent<Rigidbody2D>().AddForce(new Vector2(-sideForce * variacaoForca, upForce));
            }

            StartCoroutine("Instanciador");

        }

    }

    IEnumerator CountDown() {
        
        yield return new WaitForSeconds(1);

        AudioSource audio = GetComponent<AudioSource>();
        // audio.Play();

        if (count > 0) {
            txtCount.text = count.ToString();
            txtCountShadow.text = txtCount.text;
            txtCount.color = Color.white;
        } else {
            txtCount.text = "Já!";
            txtCountShadow.text = txtCount.text;
            txtCount.color = new Color(0.078f, 0.588f, 0.078f, 1f);
        }
        count--;
        
        // Debug.Break();

        if (count < -1) {
            goCount.SetActive(false);
            StartCoroutine("Instanciador");
        } else {
            StartCoroutine(CountDown());
            audio.Play();
        }
        
    }

}