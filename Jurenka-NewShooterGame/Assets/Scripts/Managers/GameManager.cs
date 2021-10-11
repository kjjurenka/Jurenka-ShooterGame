/***
 * Created by: Kami Jurenka
 * Date Created: 9/29/2021
 * 
 * Last Edited: 9/29/2021
 * 
 * Description: Game manager to control global game behaviors
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /***VARIABLES***/
    #region Game Manager Singleton
    static GameManager gm;//private
    public static GameManager GM { get { return gm; } }//public
    void CheckGameManagerIsInScene()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }// end CheckGameManagerIsInScene()
    #endregion

    public static int Score;
    public string ScorePrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;
    public TMP_Text NextSceneText = null;
    public TMP_Text WinnerText = null;
    public GameObject Player;
    public TMP_Sprite NextSceneButton = null;
    public static bool IsPlayerDead = false;
    public static bool Level2 = false;
    public Canvas ourCanvas = null;


    private void Awake()
    {
        CheckGameManagerIsInScene();
    }// End Awake
    // Start is called before the first frame update
    void Start()
    {
        gm.ourCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
        if (Score >= 50)
        {

    
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                NextScene();
            }
        }
        if (Score >= 1000)
        {
            WinGame();
        }
        if (IsPlayerDead)
        {
            GameOver();
        }
    }

    public static void GameOver()
    {
        if (gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(true);
        }
    }//end GameOver()
    public static void NextScene()
    {
        if (Level2 == false)
        {
            if (gm.NextSceneText != null)
            {
                gm.NextSceneText.gameObject.SetActive(true);
            }
            Score = 0;
            gm.Waiter();
            SceneManager.LoadScene("SceneLevel2");
            gm.Waiter();
            gm.NextSceneText.gameObject.SetActive(false);
            Level2 = true;
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2);
    }


    public static void WinGame()
    {
        if (gm.WinnerText != null)
        {
            gm.WinnerText.gameObject.SetActive(true);
        }
    }
}