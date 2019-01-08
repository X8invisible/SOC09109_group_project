using UnityEngine;

public class DDOL : MonoBehaviour
{
    public void Awake()
    {
        /*
         * With several classes in the game that accessing remote settings 
         * at different times, it is possible that some objects will access the 
         * settings before the asynchronous network request completes and some 
         * will access the settings afterwards, possibly resulting in inconsistent 
         * setting values. That's why this is here.
         */
        DontDestroyOnLoad(gameObject);
        //Debug.Log("DDOL " + gameObject.name);
    }
}
