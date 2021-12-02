using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgscroll : MonoBehaviour{

    public float scroll_speed = 0.25f;

    private MeshRenderer mesh_Renderer;
    // Start is called before the first frame update

    void Awake() {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scroll();
    }
    // scroll
    void scroll()
    {
        Vector2 offset = mesh_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_speed;

        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}//class
