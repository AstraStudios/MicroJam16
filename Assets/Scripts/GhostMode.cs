using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;

public class GhostMode : MonoBehaviour
{
    bool isInGhostMode = false;
    Collider2D playerCollider;
    string normalLayer = "Player";
    string ghostLayer = "Ghost";

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        gameObject.layer = LayerMask.NameToLayer(normalLayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")) {isInGhostMode = !isInGhostMode; UpdatePlayerLayer();}

        playerCollider.enabled = !isInGhostMode;
    }

    void UpdatePlayerLayer() {
        if (isInGhostMode) gameObject.layer = LayerMask.NameToLayer(ghostLayer);
        if (isInGhostMode) gameObject.layer = LayerMask.NameToLayer(normalLayer);
    }
}
