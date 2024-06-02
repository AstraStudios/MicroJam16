using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InitGame() {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }
}
