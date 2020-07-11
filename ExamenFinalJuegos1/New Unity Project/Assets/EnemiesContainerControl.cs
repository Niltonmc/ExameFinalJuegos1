using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesContainerControl : MonoBehaviour
{

    [Header("Enemy Prefab Variables")]
    public GameObject enemyPrefab;
    private EnemyControl currentEnemy;

    [Header("Creation Time Variables")]
    public float timeToCreateEnemy;

    [Header("Wave Variables")]
    public int currentWave;

    [Header("All Enemies Variables")]
    public List<string> typeEnemiesWaveList;
    public float currentEnemiesWaves;
    public float currentNumbOfEnemiesCreated;

    [Header("All Red Enemy Variables")]
    public List<Sprite> allRedEnemiesSprites;

    [Header("All Yellow Enemy Variables")]
    public List<Sprite> allYellowEnemiesSprites;

    [Header("All Fly Enemy Variables")]
    public List<Sprite> allFlyEnemiesSprites;

    [Header("All Brown Enemy Variables")]
    public List<Sprite> allBrownEnemiesSprites;

    [Header("All Cream Enemy Variables")]
    public List<Sprite> allCreamEnemiesSprites;

    [Header("Game Manager Variables")]
    public GameManagerControl gm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWaveVariables(int wave)
    {
        currentWave = wave;
        CalculateWavesVariables();
        SetTimeToCreate();
        Invoke("StartEnemyCreation", timeToCreateEnemy);
    }

    void StartEnemyCreation()
    {
        int selectEnemyType = Random.Range(0, typeEnemiesWaveList.Count);
        string typeSelected = typeEnemiesWaveList[selectEnemyType];
        Sprite spriteSelected = null;
        Vector2 posToCreate;
        float posX = 0;
        float posY = 0;

        List<int> directionValues = new List<int>(new int[] {
            -1,1});

        int directionX = 1;
        int directionY = 1;

        int scoreToAdd = 0;

        switch (typeSelected)
        {
            case "red":
                spriteSelected = allRedEnemiesSprites[
                    Random.Range(0, allRedEnemiesSprites.Count)];
                directionX = directionValues[
                    Random.Range(0, directionValues.Count)];
                posX = 9 * directionX;
                posY = -2.4f;
                scoreToAdd = 10;
                directionY = 0;
                break;

            case "yellow":
                spriteSelected = allYellowEnemiesSprites[
                              Random.Range(0, allYellowEnemiesSprites.Count)];
                directionX = directionValues[
                    Random.Range(0, directionValues.Count)];
                posX = 9 * directionX;
                posY = -2.4f;
                scoreToAdd = 15;
                directionY = 0;
                break;

            case "fly":
                spriteSelected = allFlyEnemiesSprites[
                              Random.Range(0, allFlyEnemiesSprites.Count)];
                scoreToAdd = 50;
                posX = 0;
                directionX = directionValues[Random.Range(0, directionValues.Count)];
                directionY = 0;
                posY = -2.4f;
                break;

            case "brown":
                spriteSelected = allBrownEnemiesSprites[
                              Random.Range(0, allBrownEnemiesSprites.Count)];
                scoreToAdd = 5;
                directionY = 1;
                directionX = 0;
                posY = -6.5f;
                posX = Random.Range(-6.5f, 6.5f);
                break;

            case "cream":
                spriteSelected = allCreamEnemiesSprites[
                              Random.Range(0, allCreamEnemiesSprites.Count)];
                scoreToAdd = 20;
                directionY = -1;
                directionX = 0;
                posY = 8.5f;
                posX = Random.Range(-6.5f, 6.5f);
                break;
        }

        posToCreate = new Vector2(posX, posY);
        GameObject tmp = Instantiate(enemyPrefab, posToCreate, transform.rotation);
        tmp.transform.SetParent(this.transform);
        currentEnemy = tmp.GetComponent<EnemyControl>();
        currentEnemy.SetInitialVariables(typeSelected, directionX, directionY, spriteSelected, scoreToAdd, GetComponent<EnemiesContainerControl>());
        currentNumbOfEnemiesCreated = currentNumbOfEnemiesCreated + 1;
        if (currentNumbOfEnemiesCreated >= currentEnemiesWaves)
        {
            gm.LoadNextWave();
            currentNumbOfEnemiesCreated = 0;
        }
        else
        {
            Invoke("StartEnemyCreation", timeToCreateEnemy);
        }
    }

    void CalculateWavesVariables()
    {
        currentEnemiesWaves = Mathf.Pow(2, currentWave + 1);
    }

    void SetTimeToCreate()
    {

        switch (currentWave)
        {
            case 1:
                timeToCreateEnemy = 8;
                typeEnemiesWaveList.Clear();
                typeEnemiesWaveList.Add("red");
                break;

            case 2:
                timeToCreateEnemy = 6;
                typeEnemiesWaveList.Clear();
                typeEnemiesWaveList.Add("red");
                typeEnemiesWaveList.Add("yellow");
                break;

            case 3:
                timeToCreateEnemy = 4;
                typeEnemiesWaveList.Clear();
                typeEnemiesWaveList.Add("red");
                typeEnemiesWaveList.Add("yellow");
                typeEnemiesWaveList.Add("fly");
                break;

            case 4:
                timeToCreateEnemy = 3;
                typeEnemiesWaveList.Clear();
                typeEnemiesWaveList.Add("red");
                typeEnemiesWaveList.Add("yellow");
                typeEnemiesWaveList.Add("fly");
                typeEnemiesWaveList.Add("brown");
                break;

            case 5:
                timeToCreateEnemy = 2;
                typeEnemiesWaveList.Clear();
                typeEnemiesWaveList.Add("red");
                typeEnemiesWaveList.Add("yellow");
                typeEnemiesWaveList.Add("fly");
                typeEnemiesWaveList.Add("brown");
                typeEnemiesWaveList.Add("cream");
                break;

                default:
                timeToCreateEnemy = 2;
                typeEnemiesWaveList.Clear();
                typeEnemiesWaveList.Add("red");
                typeEnemiesWaveList.Add("yellow");
                typeEnemiesWaveList.Add("fly");
                typeEnemiesWaveList.Add("brown");
                typeEnemiesWaveList.Add("cream");
                break;
        }
    }
}
