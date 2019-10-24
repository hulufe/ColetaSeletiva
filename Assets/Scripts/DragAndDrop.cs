using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{

    // o deslocamento durante o toque não permite que o lixo balance quando começa a se mover
    float deltaX, deltaY;

    // nome do lixo
    public string nomeLixo;

    // referência ao componente Rigidbody2D
    Rigidbody2D rb;

    // movimento do lixo não permitido se você não tocar no lixo pela primeira vez
    bool moveAllowed = false;
    
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D> () as Rigidbody2D;

    }


    // Update is called once per frame
    void Update () {

        // Iniciando evento de toque
        // se o evento de toque ocorrer
        if (Input.touchCount > 0) {


            // pegar posição de toque
            Touch touch = Input.GetTouch(0);


            // obter posição de toque
            Vector2 touchPos = Camera.main.ScreenToWorldPoint (touch.position);


            // definir momento da ação
            switch (touch.phase) {

                // se você tocar na tela
                case TouchPhase.Began:

                    // se você tocar no lixo
                    if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {

                        // idManager.SetTrashName(nomeLixo);

                        // get the offset between position you touches
                        // and the center of the game object
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;


                        // se o toque começar dentro do collider, ele poderá se mover
                        moveAllowed = true;


                        // restringir algumas propriedades do Rigidbody2D para que ele se mova de maneira mais suave e correta
                        rb.freezeRotation = true;
                        rb.velocity = new Vector2 (0, 0);
                        rb.gravityScale = 0;
                        GetComponent<CircleCollider2D> ().sharedMaterial = null;
                    }
                    break;


                // você move seu dedo
                case TouchPhase.Moved:
                    // se você tocar no lixo e o movimento for permitido então mova-o
                    if (GetComponent<CircleCollider2D> () == Physics2D.OverlapPoint (touchPos) && moveAllowed)
                        rb.MovePosition (new Vector2 (touchPos.x - deltaX, touchPos.y - deltaY));
                    break;


                // você solta seu dedo
                case TouchPhase.Ended:

                    // idManager.SetTrashName("");

                    // restaurar parâmetros iniciais quando o toque é finalizado
                    moveAllowed = false;
                    rb.freezeRotation = false;
                    rb.gravityScale = 2;
                    
                    break;
                
                default:
                    break;
            }
        }
    }
}