using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject enemyPrefab;  // prefab do inimigo a ser spawnado
    public int numRows = 3;  // número de fileiras de inimigos
    public int numCols = 5;  // número de inimigos por fileira
    public float spacing = 1f;  // espaçamento entre os inimigos
    public Vector2 offset = new Vector2(0f, 0f);  // offset da posição de spawn em relação ao centro da área

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("GerarFase", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GerarFase(){
        // calcular a largura e altura da área de spawn
        float width = numCols * spacing;
        float height = numRows * spacing;

        // calcular a posição inicial de spawn
        Vector2 startPos = (Vector2)transform.position - new Vector2(width / 2f, height / 2f) + offset;

        // spawnar os inimigos em fileiras
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                // calcular a posição de spawn do inimigo
                Vector2 spawnPos = startPos + new Vector2(col * spacing, row * spacing);

                // spawnar o inimigo
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
        }

    }
    



}
