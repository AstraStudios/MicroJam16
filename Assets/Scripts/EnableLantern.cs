using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLantern : MonoBehaviour
{
    [SerializeField] GameObject lantern;
    int lanternActiveInt = 0;

    // Start is called before the first frame update
    void Start()
    {
        lantern.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E) && lanternActiveInt == 0) {
        lantern.SetActive(true);
        lanternActiveInt = 1;
       }
       if (Input.GetKeyDown(KeyCode.E) && lanternActiveInt == 1) {
        lantern.SetActive(false);
        lanternActiveInt = 0;
       }
    }
}
