using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManagerControl : MonoBehaviour
{
     [Header("Waves Variables")]
     public Text txtWave;
    public int currentWave;

     [Header("Enemies Variables")]
     public EnemiesContainerControl enemiesContainer;

     [Header("Lives Variables")]
    public Text txtLives;

      [Header("Score Variables")]
    public Text txtScore;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        CalculateWavesVariables();
        UpdateWave();
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int lives){
        txtLives.text = "Lives: " + lives.ToString();
        if(lives<=0){
            PlayerPrefs.SetInt("Score",score);
             SceneManager.LoadScene("GameOver");
        }
    }

    public void UpdateScore(int val){
        score = score + val;
        txtScore.text = "Score: " + score.ToString();
    }

     void UpdateWave(){
        txtWave.text = "Wave: " + currentWave.ToString();
    }

    void CalculateWavesVariables(){
        enemiesContainer.SetWaveVariables(currentWave);
    }

    public void LoadNextWave(){
        currentWave = currentWave +1;
        UpdateWave();
        CalculateWavesVariables();
    }
}
