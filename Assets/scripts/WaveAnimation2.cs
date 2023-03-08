using System.Collections;
using ySstem.Collections.Generic;
using UnityEngine;

public class WaveAnimation2 : MonoBehaviour
{
    public float speed = 1f; // velocidade do movimento da onda
    public float scale = 1f; // escala da onda
    public float maxAmplitude = 0.5f; // amplitude máxima da onda
    public float frequency = 1f; // frequência da onda

    private float[] initialYPos; // posições iniciais em Y dos objetos
    private float[] timeOffsets; // deslocamentos de tempo para cada objeto

    // Start é chamado antes da primeira atualização do quadro
    void Start()
    {
        int numObjects = transform.childCount;
        initialYPos = new float[numObjects];
        timeOffsets = new float[numObjects];

        // armazena as posições iniciais em Y dos objetos
        for (int i = 0; i < numObjects; i++)
        {
            initialYPos[i] = transform.GetChild(i).position.y;
        }

        // gera deslocamentos de tempo aleatórios para cada objeto
        for (int i = 0; i < numObjects; i++)
        {
            timeOffsets[i] = Random.Range(0f, 2f * Mathf.PI);
        }
    }

    // Update é chamado uma vez por quadro
    void Update()
    {
        int numObjects = transform.childCount;

        // atualiza a posição e escala de cada objeto
        for (int i = 0; i < numObjects; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 pos = child.position;

            // calcula a posição Y da onda
            float time = Time.time * speed + timeOffsets[i];
            float yPos = initialYPos[i] + maxAmplitude * Mathf.Sin(time * frequency);

            // atualiza a posição do objeto
            pos.y = yPos;
            child.position = pos;

            // calcula a escala da onda
            float scaleFactor = 1f + scale * Mathf.Sin(time * frequency);
            child.localScale = new Vector3(scaleFactor, 1f, 1f);
        }
    }
}
