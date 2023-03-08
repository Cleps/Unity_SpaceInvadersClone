using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f; // Velocidade da bala
    public Vector2 direction = Vector2.up; // Direção da bala
    private TextController TextControl;

    void Start(){
        TextControl = FindObjectOfType<TextController>();
    }
    // Atualiza a cada quadro
    void Update()
    {   
        // Move a bala na direção definida
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Chamado quando a bala colide com outro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se a bala colidiu com um inimigo
        if (collision.CompareTag("Enemy"))
        {
            // Destrói o inimigo
            Destroy(collision.gameObject);
            // Destrói a bala
            Destroy(gameObject);
            
            TextControl.UpScore(100);
            
        }
    }


}
