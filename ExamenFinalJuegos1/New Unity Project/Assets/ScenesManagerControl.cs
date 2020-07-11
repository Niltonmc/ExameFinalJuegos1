using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManagerControl : MonoBehaviour
{

    [Header("All Scene Buttons Variables")]
    public Button btnSelection;
    public Button btnNormalGame;
    public Button btnHardGame;

    [Header("All Scene Names Variables")]
    public string nameSelectionScene;
    public string nameGameScene;
     public string nameMenuScene;

    [Header("All Player Prefs Variables")]
    public string namePlayerLivesPref;

     [Header("Texts Variables")]
     public Text txtScore;

    // Start is called before the first frame update
    void Start()
    {
        if (btnSelection != null)
        {
            btnSelection.onClick.AddListener(() => GoSelection());
        }

        if (btnNormalGame != null)
        {
            btnNormalGame.onClick.AddListener(() => GoNormalGame());
        }

        if (btnHardGame != null)
        {
            btnHardGame.onClick.AddListener(() => GoHardGame());
        }

        if (btnSelection == null && btnNormalGame == null && btnHardGame == null){
            txtScore.text = "SCORE: " + PlayerPrefs.GetInt("Score",0);
            Invoke("GoMenu",3);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GoSelection()
    {
        SceneManager.LoadScene(nameSelectionScene);
    }

    void GoNormalGame()
    {
        SceneManager.LoadScene(nameGameScene);
        PlayerPrefs.SetInt(namePlayerLivesPref, 4);
    }

    void GoHardGame()
    {
        SceneManager.LoadScene(nameGameScene);
        PlayerPrefs.SetInt(namePlayerLivesPref, 1);
    }

     void GoMenu()
    {
        SceneManager.LoadScene(nameMenuScene);
    }
}
