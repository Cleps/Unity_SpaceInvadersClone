using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bullet : MonoBehaviour {
    public float speed = 10f;
    public Vector2 direction;
    public AudioClip somDeGameover;
    private AudioSource audioSouce;
    private PlayerControll player;
    public GameObject youDieScreen;

    private void Update() {
        // Mover a bala na direção definida
        transform.Translate(direction * speed * Time.deltaTime);
        audioSouce = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerControll>();
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        // Verificar se o inimigo colidiu com o jogador
        if (collision.CompareTag("Player")) {
            player.killPlayer = true;
            audioSouce.PlayOneShot(somDeGameover);
            // Fazer algo quando o jogador é atingido pelo inimigo
            Destroy(collision.gameObject, 0.35f);
            youDieScreen.SetActive(true);
            //StartCoroutine(ResetAfterDelay());
                      
        }
    }


    private IEnumerator ResetAfterDelay(){
        yield return new WaitForSeconds(1.18f);
        SceneManager.LoadScene(1);
    }
}
