using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowLantern : MonoBehaviour
{
    GameObject lantern;

    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        lantern = GameObject.FindGameObjectWithTag("Lantern");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentLanternPos = new Vector3(lantern.transform.position.x, lantern.transform.position.y, 0);
        var step = speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, lantern.transform.position) > 0.001f) {
            transform.position = Vector3.MoveTowards(transform.position, currentLanternPos, step);
        }
    }
}
