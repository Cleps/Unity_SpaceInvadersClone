using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControll : MonoBehaviour
{   
    public GameObject menuprincipal;
    public GameObject menuinstru;
    // Start is called before the first frame update
    void Start()
    {
        menuinstru.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public void Instrucoes(){
        menuprincipal.SetActive(false);
        menuinstru.SetActive(true);
    }

    public void Principalmenu(){
        menuinstru.SetActive(false);
        menuprincipal.SetActive(true);
    }

    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    public void Exitgame(){
         Application.Quit();
    }

}
