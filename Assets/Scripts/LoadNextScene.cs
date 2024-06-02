using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    int currSceneIndex;
    int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextScene += currSceneIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Dude")) {
            SceneManager.LoadScene(nextScene);
        }
    }
}
