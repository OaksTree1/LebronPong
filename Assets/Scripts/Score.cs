using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text Scoreboard;
    LebronMovement lebron;
    bool Win = false;
    public static bool CanAdd1 = true;
    public static bool CanAdd2 = true;
    public Menu menu;

    private int Score_paddle1 = -1;
    private int Score_paddle2 = -1;

    // Start is called before the first frame update
    void Start()
    {
        lebron = FindObjectOfType<LebronMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Score_paddle1 >= 7)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            menu.TextCity("Paddle1 Wins");


        }
        if(Score_paddle2 >= 7)
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            menu.TextCity("Paddle2 Wins");

        }
        if(CanAdd1)
        {
            CanAdd1 = false;
            Score_paddle1 += 1;
        }
        if(CanAdd2)
        {
            CanAdd2 = false;
            Score_paddle2 += 1;
        }

        Scoreboard.text = $"" + Score_paddle1.ToString() + $":" + Score_paddle2.ToString();
    }
}
