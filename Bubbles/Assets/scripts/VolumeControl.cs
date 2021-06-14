using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider voulumeSlider;
    public AudioSource mainAudioSource;

    void Start()
    {
        mainAudioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        voulumeSlider.value = mainAudioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        mainAudioSource.volume = voulumeSlider.value;
    }
}
