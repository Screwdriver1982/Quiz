using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRecord : MonoBehaviour
{
    public int maxQuestions;
    public int playerRecord =0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
