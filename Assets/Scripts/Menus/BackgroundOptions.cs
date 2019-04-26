using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOptions : MonoBehaviour
{
  public GameObject[] backgrounds;

  void DisableAll()
  {
    foreach(GameObject b in backgrounds)
    {
      b.SetActive(false);
    }
  }

  public void Background1Click()
  {
    DisableAll();
    backgrounds[1].SetActive(true);
  }
  public void Background2Click()
  {
    DisableAll();
    backgrounds[2].SetActive(true);
  }
  public void Background3Click()
  {
    DisableAll();
    backgrounds[3].SetActive(true);
  }
  public void Background4Click()
  {
    DisableAll();
    backgrounds[4].SetActive(true);
  }
  public void BackgroundDefClick()
  {
    DisableAll();
    backgrounds[0].SetActive(true);
  }
  public void BackgroundNightDayClick()
  {
    DisableAll();
    backgrounds[1].SetActive(true);
  }
}
