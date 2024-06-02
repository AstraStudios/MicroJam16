using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] AudioClip gloriousSpeech;
    private int clickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        clickCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = gloriousSpeech;
        if (Input.GetMouseButtonDown(0)) clickCount++;
        if (clickCount == 4) {
            audioPlayer.Play(); StartCoroutine(QuitGame()); clickCount++;
        }

        Debug.Log(clickCount);
    }

    IEnumerator QuitGame() {
        yield return new WaitForSeconds(7);
        Application.Quit();
    }
}
