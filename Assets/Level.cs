using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static Level instance;

    uint numDestruction = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 2;
    string[] levels = { "Level1", "Level2" };
    int currentLevel = 1;

    int score = 0;
    Text scoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if(nextLevelTimer <= 0)
            {
                currentLevel++;
                if(currentLevel <= levels.Length)
                {
                    string senceName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(senceName);
                }
                else
                {
                    Debug.Log("GAME OVER!!!");
                }
                nextLevelTimer = 2;
                startNextLevel = false;
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddScore(int ammountToAdd)
    {
        score += ammountToAdd;
        scoreText.text = score.ToString();
    }

    public void AddDestruction()
    {
        numDestruction++;
    }

    public void RemoveDestruction()
    {
        numDestruction--;
        if(numDestruction == 0)
        {
            startNextLevel = true;
        }
    }
}
