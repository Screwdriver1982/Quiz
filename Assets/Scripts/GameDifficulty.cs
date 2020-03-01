using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public int difficulty = 0;

    public void SetDifficulty(int playerChoice)
    {
        difficulty = playerChoice;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

   
}
