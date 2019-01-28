using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public BoardManager boardManager;
    public static GameManager instance = null;


    private int level = 1;

    void InitGame()
    {
        boardManager.SetupScene(level);
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        boardManager = GetComponent<BoardManager>();
        InitGame();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void resetScene()
    {
        boardManager.SetupScene(level);
    }
}
