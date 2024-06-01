using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowLantern : MonoBehaviour
{
    GameObject lantern;
    GameObject[] ramps; // might remove this later

    GameObject[] obstacles; // might also remove

    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        ramps = GameObject.FindGameObjectsWithTag("Ramp");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentLanternPosZLock = new Vector3(lantern.transform.position.x, lantern.transform.position.y, 0);
        Vector3 currentLanternPosZFree = new Vector3(lantern.transform.position.x, lantern.transform.position.y, lantern.transform.position.z);
        var step = speed * Time.deltaTime;
        
        for (int d = 0; d < obstacles.Length; d++) {
            Debug.DrawRay(transform.position, obstacles[d].transform.position, Color.red);

            if (Vector3.Distance(transform.position, obstacles[d].transform.position) > 1f) {
                if (Vector3.Distance(transform.position, lantern.transform.position) > 0.001f) {
                    transform.position = Vector3.MoveTowards(transform.position, currentLanternPosZLock, step);
                }
            } else Debug.Log("I cannot go any further || sorry for spam");
            
            for (int f = 0; f < ramps.Length; f++) {
                RaycastHit2D rampHit = Physics2D.Raycast(transform.position, ramps[f].transform.position, 3f);
                Debug.DrawRay(transform.position, ramps[f].transform.position, Color.blue);
                if (rampHit.collider != null) {
                    transform.position = Vector3.MoveTowards(transform.position, currentLanternPosZFree, step);
                }
            }
        }
    }
}
