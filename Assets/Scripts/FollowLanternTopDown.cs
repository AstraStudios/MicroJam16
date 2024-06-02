using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;

public class FollowLanternTopDown : MonoBehaviour
{
    GameObject lantern;
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        if (lantern!=null) MoveCharacter(); Debug.DrawRay(transform.position, lantern.transform.position, Color.red);
    }

    void MoveCharacter() {
        Vector3 currentLanternPos = lantern.transform.position;
        var step = speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, currentLanternPos) > 0.5f) transform.position = Vector3.MoveTowards(transform.position, currentLanternPos, step);
    }
}
