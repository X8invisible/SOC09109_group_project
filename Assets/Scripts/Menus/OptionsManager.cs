using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    bool checkbox = true;
    public GameObject lights;
    public GameObject directional;

    public void OnValueChanged()
    {
        Debug.Log(checkbox);
        lights.SetActive(checkbox);
        directional.SetActive(!checkbox);
        checkbox = !checkbox;
    }
}
