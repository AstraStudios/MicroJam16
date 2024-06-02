using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    AudioSource audioPlayer;
    int currentClipIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioPlayer = gameObject.GetComponent<AudioSource>();
        audioPlayer.loop = false;
        PlayNextClip();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioPlayer.isPlaying)
            PlayNextClip();
    }

    void PlayNextClip()
    {
        audioPlayer.clip = audioClips[currentClipIndex];

        audioPlayer.Play();
    }
}
