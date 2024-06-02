using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;

public class GhostMode : MonoBehaviour
{
    bool isInGhostMode = false;
    string normalLayer = "Player";
    string ghostLayer = "Ghost";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer(normalLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")) {isInGhostMode = !isInGhostMode; UpdatePlayerLayer();}
    }

    void UpdatePlayerLayer() {
        if (isInGhostMode) gameObject.layer = LayerMask.NameToLayer(ghostLayer);
        else gameObject.layer = LayerMask.NameToLayer(normalLayer);
    }
}
