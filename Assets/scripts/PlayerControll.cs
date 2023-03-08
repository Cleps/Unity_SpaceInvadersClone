using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControll : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject bulletPrefab;  // a prefab da bala
    public float tempoacadaTiro = 2f;
    private Rigidbody2D rb;

    public AudioClip somDeTiro;
    private AudioSource sound;
    Animator anim;
    public bool killPlayer = false;

    void Start()
    {   
        sound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(tempoDeTiro());
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        // transform.Translate(Vector2.right * horizontal * moveSpeed * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (horizontal < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (killPlayer){
            anim.Play("deadAnim");            
        }

    }

    IEnumerator tempoDeTiro(){
        while (true){
            yield return new WaitForSeconds(tempoacadaTiro);
            sound.PlayOneShot(somDeTiro);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        }
    }

}
