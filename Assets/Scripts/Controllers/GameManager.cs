using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public BoardManager boardScript;
    public static GameManager instance = null;


    private int level = 1;

    void InitGame()
    {
        boardScript.SetupScene(level);
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        boardScript = GetComponent<BoardManager>();
        InitGame();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
