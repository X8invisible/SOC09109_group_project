﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }
    //dimensions of the game board
    public int columns;
    public int rows;

    //how many trees do we want in a level
    public Count treeCount = new Count(5, 10);
    // how many items we want in a level
    public Count itemCount = new Count(1, 5);


    //for storing multiple game objects of same type
    public GameObject[] floorTiles;
    public GameObject[] treeTiles;
    public GameObject[] outerWallTiles;
    // this is what i am working on (for item pickup)
    public GameObject[] itemTiles;


    //used to store all the objects spawned to keep it clean
    private Transform boardHolder;

    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();
        //loops through the grid, without the edges of the map
        for(int x = 0; x < columns - 1; x++)
        {
            for (int y =0; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        //loops through the grid, but also outside the 'playable' edge in order to create the confining wall
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                //if the position is an edge, choose a wall instead
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x+(int)transform.position.x, y+ (int)transform.position.y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    //gets a random x,y position
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }

    //how many objects to spawn on the map(like trees, rocks, etc.)
    void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);

        for(int i=0; i<objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);

        }
    }


    //actually sets up the scene, more things can be added later
    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(treeTiles, treeCount.minimum, treeCount.maximum);

        LayoutObjectAtRandom(itemTiles, itemCount.minimum, itemCount.maximum);

    }
}
