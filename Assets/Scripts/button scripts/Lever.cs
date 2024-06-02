using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToBeMoved;
    [SerializeField] Vector2[] objectsDestination;
    float movementLerpTimer = 0f;
    [SerializeField] float movementTime;
    bool isActivated = false;
    [SerializeField] GameObject leverOff;
    [SerializeField] GameObject leverOn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated) {
            movementLerpTimer += Time.deltaTime / movementTime;

            if (movementLerpTimer > 1) {
                isActivated = false;
                movementLerpTimer = 1;
            }            

            for (int p = 0; p < objectsToBeMoved.Length; p++) {
                float smoothTime = Mathf.SmoothStep(0f, 1f, movementLerpTimer);
                objectsToBeMoved[p].gameObject.transform.position = Vector2.Lerp(objectsToBeMoved[p].transform.position, objectsDestination[p], smoothTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            isActivated = true;
            leverOff.SetActive(false);
            leverOn.SetActive(true);
        }
    }
}
