using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStaySize : MonoBehaviour
{
    [SerializeField] float unitsToShowHorizontally = 20f;

    // Start is called before the first frame update
    void Start()
    {
        float screenWidth = unitsToShowHorizontally;

        float screenHeight = screenWidth * Screen.height / Screen.width;

        float orthoSize = screenHeight/2f;

        Camera.main.orthographicSize = orthoSize;

        Camera.main.aspect = screenWidth / screenHeight;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
