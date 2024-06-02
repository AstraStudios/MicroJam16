// script should be on player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;

public class CameraController : MonoBehaviour
{
    [SerializeField] float unitsToShowHorizontally = 20f;
    public int activeZone = 0;
    int activeZoneY = 0;

    private void Update()
    {
        // fix horizontal units
        float screenWidth = unitsToShowHorizontally;
        float screenHeight = screenWidth * Screen.height / Screen.width;
        float orthoSize = screenHeight / 2f;

        Camera.main.orthographicSize = orthoSize;
        Camera.main.aspect = screenWidth / screenHeight;

        // move camera to active zone
        activeZone = Mathf.RoundToInt(transform.position.x / screenWidth);
        activeZoneY = Mathf.RoundToInt(transform.position.y / screenHeight);

        Camera.main.transform.position = F.vec3(activeZone * unitsToShowHorizontally, activeZoneY * orthoSize, -10);

    }
}
