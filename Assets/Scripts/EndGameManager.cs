using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public Text endGame;
    int maxQuestion;
    int playerRecord;
    // Start is called before the first frame update
    void Start()
    {
        GameRecord gameRecordComponent = FindObjectOfType<GameRecord>();
        maxQuestion = gameRecordComponent.maxQuestions;
        playerRecord = gameRecordComponent.playerRecord;
        if (playerRecord == maxQuestion)
        {
            endGame.text = "Congatulation! You won!";
        }
        else
        { 
            endGame.text = "You've answered: " + playerRecord + " from " + maxQuestion;
        } 
        
    }

}
