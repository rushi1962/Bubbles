using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] musicSources = GameObject.FindGameObjectsWithTag("Music");
        if(musicSources.Length>1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        if(!camera)
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }
        else
        {
            transform.position = camera.transform.position;
        }
    }
}
