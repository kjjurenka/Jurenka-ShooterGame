/***
 * Created by: Kami Jurenka
 * Date Created: 9/29/2021
 * 
 * Last Edited: 9/29/2021
 * 
 * Description: Adds to score when object destoryed
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    /***VARIABLES***/
    public int ScoreValue = 50;
    private void OnDestroy()
    {
        GameManager.Score += ScoreValue;
    }//end OnDestory()
}
