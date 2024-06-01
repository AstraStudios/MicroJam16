// script should be on player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;

public class CameraController : MonoBehaviour
{
    public int activeZone = 0;

    private void Update()
    {
        // caclulate screen width in unity units
        float aspect = (float)Screen.width / Screen.height;
        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * aspect;

        activeZone = Mathf.RoundToInt(transform.position.x / worldWidth);

        Camera.main.transform.position = F.vec3(activeZone * worldWidth, 0, -10);
    }
}
