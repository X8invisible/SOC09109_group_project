using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CarShadow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0.1f,0.14f);
    public Vector3 scale = new Vector3(1f,1f,0);
    public Material material;
    Transform tranParent;
    GameObject shadow;
    void Start()
    {
        //create a 'clone' game object that is offset from the parent
        shadow = new GameObject("CarShadow");
        tranParent = transform;
        shadow.transform.parent = tranParent;
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
        shadow.transform.position = new Vector3(tranParent.position.x + offset.x, tranParent.position.y + offset.y, 0f);
    }
}
