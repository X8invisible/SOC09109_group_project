using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //public GameObject chunkGO;
    public static GameManager instance = null;
	//Dictionary<Vector2, Chunk> chunkMap;
	private Car car;
	//public float renderDistance;
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
		//chunkMap = new Dictionary<Vector2, Chunk>();

	}
	private void Start()
	{
		car = GameObject.FindWithTag("Car").GetComponent<Car>();
		//FindChunk();
	}
	// Update is called once per frame
	void Update()
    {
		//FindChunk();
		//DeleteChunk();
	}
/* 
	void FindChunk()
	{
		int carX = (int)car.transform.position.x;
		int carY = (int)car.transform.position.y;
		for (int i = carX - Chunk.size; i < carX + (Chunk.size*2); i+=Chunk.size)
		{
			for (int j = carY - Chunk.size; j < carY + (Chunk.size*2); j+=Chunk.size)
			{
				//if (chunkMap.ContainsKey(new Vector2(i, j)) == false)
					MakeChunkAt(i, j);
				
			}
		}
		
	}
	void MakeChunkAt(int x, int y)
	{
		x = Mathf.FloorToInt(x / (float)Chunk.size) * Chunk.size;
		y = Mathf.FloorToInt(y / (float)Chunk.size) * Chunk.size;

		if(chunkMap.ContainsKey(new Vector2(x, y)) == false)
		{
			GameObject c = (GameObject) Instantiate(chunkGO, new Vector3(x, y, 0f), Quaternion.identity);
			chunkMap.Add(new Vector2(x, y), c.GetComponent<Chunk>());
		}
	}

	void DeleteChunk()
	{
		List<Chunk> delChunks = new List<Chunk>(chunkMap.Values);
		Queue<Chunk> delQueue = new Queue<Chunk>();
		for (int i = 0; i < delChunks.Count; i++)
		{
			float distance = Vector3.Distance(car.transform.position, delChunks[i].transform.position);

			if(distance > renderDistance * Chunk.size)
			{
				delQueue.Enqueue(delChunks[i]);
			}
		}

		while(delQueue.Count > 0)
		{
			Chunk ch = delQueue.Dequeue();
			chunkMap.Remove(ch.transform.position);
			Destroy(ch.gameObject);
		}
	}
	*/
}
