using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.1f;

    private float Y_Axis;

    private Material bgMaterial;

    private void Awake()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Y_Axis += speed * Time.deltaTime;
        bgMaterial.SetTextureOffset("_MainTex", new Vector2(0f, Y_Axis));
    }

}
