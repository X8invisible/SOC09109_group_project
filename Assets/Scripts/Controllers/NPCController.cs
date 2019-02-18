using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    // For accessing the car game object so we can access it's components through the car script
    public GameObject npcGameObject;

    public GameObject player;
    // The car script that changes the car game object
    private NPC npc;

    // Start is called before the first frame update
    void Start()
    {
        npc = npcGameObject.GetComponent<NPC>();
        player = GameObject.FindGameObjectWithTag("Car");
    }

    // This is called once per frame
    void Update()
    {
      /*if ((GameObject.FindGameObjectWithTag("NPC").transform.position.y) < (GameObject.FindGameObjectWithTag("Car").transform.position.y))
      {
        npc.Accelerate(1);
      }

      else if ((GameObject.FindGameObjectWithTag("NPC").transform.position.y) > (GameObject.FindGameObjectWithTag("Car").transform.position.y))
      {
        npc.Accelerate(-1);
      }*/
    }


    void LookAtPlayer()
    {
    }
}
