using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    bool checkbox = false;
    public GameObject lights;
    public GameObject directional;

    public void OnValueChanged()
    {
        checkbox = !checkbox;
        if(checkbox)
        {
            lights.GetComponent<Light>().intensity = 10.0f;
            directional.GetComponent<Light>().intensity = 0.0f;

        }else
        {
            lights.GetComponent<Light>().intensity = 0.0f;
            directional.GetComponent<Light>().intensity = 1.0f;
        }
    }
}
