using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public float speed = 3f;
    public float timeBetweenShots = 3f;
    public float delay;
    public GameObject bulletPrefab;
    private float direction = 1;
    public float tempoMudarDirecao;
    Animator anim;
    private GameController gamecontrol;
    // Start is called before the first frame update
    void Start()
    {
        gamecontrol = FindObjectOfType<GameController>();
        anim = GetComponent<Animator>();
        StartCoroutine(ShootRoutine());
        StartCoroutine(Changedir());
    }

    // mudar a direção

    IEnumerator Changedir(){
        while (true){
            yield return new WaitForSeconds(tempoMudarDirecao);

            direction = direction * -1;
        }
    }

    // Update is called once per frame
    IEnumerator ShootRoutine() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(delay, timeBetweenShots));

            Invoke("Shoot", 0f);
        }
    }

    void Update(){
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        //animações
        if (gamecontrol.currentLevel <=3)
        {
            anim.Play("Enemy");
        }
        else if (gamecontrol.currentLevel >=4 && gamecontrol.currentLevel <=7)
        {
            anim.Play("Enemy2");
        }
        else {
            anim.Play("Enemy3");
        }
    
    }

    private void Shoot() {
        // Criar uma bala e definir sua posição e rotação
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Definir a direção da bala para baixo
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = Vector2.down;
        Destroy(bullet, 2f);

    }


}
