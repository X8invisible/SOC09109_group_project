using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CarShadow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0.4f,0.4f);
    public Vector3 scale = new Vector3(1.2f,1.2f,0);
    public Material material;
    GameObject shadow;
    void Start()
    {
        //create a 'clone' game object that is offset from the parent
        shadow = new GameObject("CarShadow");
        shadow.transform.parent = transform;
        shadow.transform.localPosition = offset;
        shadow.transform.localRotation = Quaternion.identity;
        shadow.transform.localScale = scale;
        //we need the sprite from the parent
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        SpriteRenderer sr = shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = material;
        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder -1;
    }
    void LateUpdate()
    {
        shadow.transform.localPosition = offset;
    }
}
