using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public Text lvl;
    public Text ScoreP;
    public Text Hiscor;
    private GameController game;
    private PlayerBullet playerbul;
    public int score = 0;
    public int hiscore = 0;

    void Start()
    {
        game = FindObjectOfType<GameController>();
        playerbul = FindObjectOfType<PlayerBullet>();
        // Define o texto do objeto Text
        //myText.text = "Olá, mundo!";
        hiscore = PlayerPrefs.GetInt("HiScore");
    }

    void Update()
    {
        string level = game.currentLevel.ToString();
        // Muda o texto do objeto Text a cada frame
        lvl.text = "Level: " + level;

        string scoreplayer = score.ToString();
        ScoreP.text = "Score: "+ scoreplayer;

        string hisc = hiscore.ToString();
        Hiscor.text = "Hi-Score: "+ hisc;

        if (Input.GetKeyDown(KeyCode.F9)) {
            PlayerPrefs.DeleteKey("HiScore");
            hiscore = 0;
            Hiscor.text = "Hi-Score: 0";
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }


        // HI-Score
        if (score >= hiscore){
            // Salva a pontuação atual do jogador (nome da variavel, variavel com o int)
            PlayerPrefs.SetInt("HiScore", score);
            hiscore = score;
        }

    }

    public void UpScore(int pontos){
        score += pontos;
    }

}
