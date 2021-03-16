using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    int currentLevel = 0;
    
    public static float realtimer = 0;

    public Text text;

    public static int ingame;

    private static int score = 0;

    const string DIR_LOGS = "/Logs";
    const string FILE_SCORES = DIR_LOGS + "/highScore.txt";
    const string FILE_ALL_SCORES = DIR_LOGS + "/allScores.csv";
    public static string FILE_PATH_HIGH_SCORES;
    public static string FILE_PATH_ALL_SCORES;

    public static int highScore = -1;
    public static int Score
    {
        get { return score; }
        set
        {
            score = value;

            if (score > HighScore)
            {
                HighScore = score;
            }

            string fileContents = "";
            if (File.Exists(FILE_PATH_ALL_SCORES))
            {
                fileContents = File.ReadAllText(FILE_PATH_ALL_SCORES);
            }

            fileContents += score + ",";
            File.WriteAllText(FILE_PATH_ALL_SCORES, fileContents);
            
        }
    }

    public static int HighScore
    {
        get
        {
            if (highScore < 0)
            {
                if (File.Exists(FILE_PATH_HIGH_SCORES))
                {
                    string fileContents = File.ReadAllText(FILE_PATH_HIGH_SCORES);
                    highScore = Int32.Parse(fileContents);

                }
            }

            return highScore;
        }

        set
        {
            highScore = value;
            if (!File.Exists(FILE_PATH_HIGH_SCORES))
            {
                Directory.CreateDirectory(Application.dataPath + DIR_LOGS);
            }
            
            File.WriteAllText(FILE_PATH_HIGH_SCORES, highScore + "");
        }
    }
    
    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ingame = 1;
        realtimer = 0;

        score = 0;

        FILE_PATH_ALL_SCORES = Application.dataPath + FILE_SCORES;
        FILE_PATH_HIGH_SCORES = Application.dataPath + FILE_ALL_SCORES;
    }

    // Update is called once per frame
    void Update()
    {
        print(ingame);
        if (ingame == 1){
            realtimer += Time.deltaTime;
            text.text = "Time: " + (int) realtimer;
        }
        
        if(ingame ==0)
        {
            text.text = "Your Score is: " + (int)realtimer + " seconds";
        }
    }
    
        
}
