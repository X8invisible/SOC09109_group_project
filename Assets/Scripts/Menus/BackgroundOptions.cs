using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOptions : MonoBehaviour
{
  public GameObject[] backgrounds;
  public SpriteRenderer[] dayNight;
  public Light world;
  public Light headlight;
  float transitionWorld = 0.0f;
  float transitionHeadlight = 1.0f;
  float transitionSpeed = 0.05f;
  bool nightMode = false, day =true;

void Update()
{
  if(nightMode)
  {
    transitionWorld += (day)?transitionSpeed*Time.deltaTime: - transitionSpeed * Time.deltaTime;
    float alphaDay = Mathf.Lerp(0.0f, 1.0f, transitionWorld);
    transitionHeadlight += (!day)?transitionSpeed*Time.deltaTime: - transitionSpeed * Time.deltaTime;
    float alphaNight = Mathf.Lerp(0.0f, 1.0f, transitionHeadlight);
    if(transitionWorld < 0.0f || transitionWorld > 1.0f)
      day = !day;
    world.intensity = transitionWorld;
    Color t = dayNight[0].color;
    t.a = alphaDay;
    dayNight[0].color = t;
    t = dayNight[1].color;
    t.a = alphaNight;
    dayNight[1].color = t;
    
    headlight.intensity = transitionHeadlight*10;
  }

}
  void DisableAll()
  {
    nightMode = false;
    world.intensity = 1.0f;
    headlight.intensity = 0.0f;
    foreach(GameObject b in backgrounds)
    {
      b.SetActive(false);
    }
  }

  public void Background1Click()
  {
    DisableAll();
    backgrounds[0].SetActive(true);
  }
  public void Background2Click()
  {
    DisableAll();
    backgrounds[1].SetActive(true);
  }
  public void Background3Click()
  {
    DisableAll();
    backgrounds[2].SetActive(true);
  }
  public void Background4Click()
  {
    DisableAll();
    backgrounds[3].SetActive(true);
  }
  public void BackgroundDefClick()
  {
    DisableAll();
    backgrounds[4].SetActive(true);
  }
  public void BackgroundNightDayClick()
  {
    DisableAll();
    backgrounds[5].SetActive(true);
    backgrounds[6].SetActive(true);
    nightMode = true;
  }


}
