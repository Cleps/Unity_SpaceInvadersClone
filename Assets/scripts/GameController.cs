using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    public int currentLevel = 1;
    public EnemyControll enemyController;
    public SpawnArea spawnarea;
    private Bullet enemyBullet;
    private PlayerBullet playerbullet;
    private PlayerControll playercontroll;
    // Start is called before the first frame update
    void Start()
    {
        // para referenciar o objeto
        enemyBullet = FindObjectOfType<Bullet>();
        playerbullet = FindObjectOfType<PlayerBullet>();
        spawnarea.GerarFase();
        playercontroll = FindObjectOfType<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {   // LEVEL 1 AO 4
        if (currentLevel >=1 && currentLevel <=3)
        {
                int numInimigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (numInimigos <= 1){
                    spawnarea.numRows += 1;
                    spawnarea.numCols += 1;
                    spawnarea.GerarFase();
                    currentLevel++;
                    playerbullet.speed += 0.8f;
                    playercontroll.tempoacadaTiro -= 0.1f;
                }
        }
        // LEVEL 5 AO 8
        if (currentLevel >=4 && currentLevel <=7){
                int numInimigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (numInimigos <= 1){
                    spawnarea.numCols += 1;
                    spawnarea.GerarFase();
                    currentLevel++;
                    playerbullet.speed += 0.8f;
                    playercontroll.tempoacadaTiro -= 0.1f;
                }

        }
        // DO LVL 8 EM DIANTE
        if (currentLevel >=8){
                int numInimigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if (numInimigos <= 1){
                    enemyBullet.speed += 0.75f;
                    spawnarea.GerarFase();
                    currentLevel++;
                    playerbullet.speed += 0.8f;
                    playercontroll.tempoacadaTiro -= 0.1f;
                }
        }

        if (Input.GetKeyDown(KeyCode.F1)){
            SceneManager.LoadScene(1);
        }
    }


}
