using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    // For accessing the car game object so we can access it's components through the car script
    public GameObject npcGameObject;

    // The car script that changes the car game object
    private NPC npc;

    // Start is called before the first frame update
    void Start()
    {
        npc = npcGameObject.GetComponent<NPC>();
    }

    // This is called once per frame
    void Update()
    {
      npc.Accelerate(1);
      npc.RotateRight();
    }
}
