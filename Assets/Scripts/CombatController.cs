using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLSLVectors;
using Unity.Mathematics;

public class CombatController : MonoBehaviour
{

    [SerializeField] GameObject attack;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 camPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z));
            Instantiate(attack, new Vector2(camPoint.x, camPoint.y), Quaternion.identity);
        }
    }

    static Vector3 GetVectorFromAngle(float angle) {
        float angleRad = angle * (Mathf.PI/180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    } // thanks code monkey for inspiration
}
