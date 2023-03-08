using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    public float speed = 1.0f;  // velocidade da onda
    public float amplitude = 0.5f;  // amplitude da onda
    public float frequency = 1.0f;  // frequência da onda

    private Vector3 posOffset;
    private Vector3 tempPos;

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        // mover objeto para cima e para baixo como uma onda
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        // rotacionar objeto como uma onda
        transform.rotation = Quaternion.Euler(Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude * 10.0f, 0.0f, 0.0f);

        // mover objeto
        transform.position = Vector3.Lerp(transform.position, tempPos, speed * Time.deltaTime);
    }
}
