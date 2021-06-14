using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform nextPosition;
    public bool release;
    public TargetManager targetManager;
    public float speed=5f;
    public bool dead,shielded;
    public float shieldTime=2f;
    public GameObject shield;
    //public AudioSource bubbleSFX;
   // bool isPlaying;
    //public int levels = 0;
    void Start()
    {
        targetManager = GameObject.FindGameObjectWithTag("TargetManager").GetComponent<TargetManager>();
        dead = false;
        shieldTime = 2f;
        //speed = 0f;
        //isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = targetManager.targets[4].transform;
        if(nextPosition&&release&&Vector3.Distance(transform.position,nextPosition.position)>=0.1f)
        {
             transform.Translate((nextPosition.position-transform.position).normalized*speed*Time.deltaTime);
            //speed = 5f;

        }
        else if(nextPosition && release && Vector3.Distance(transform.position, nextPosition.position) < 0.1f)
        {
            transform.position = nextPosition.position;
            //speed = 0f;
            release = false;
        }
        if(shielded)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            if(shieldTime > 0f)
            {
                shieldTime -= Time.deltaTime;
            }
            else if(shieldTime<0f)
            {
                shieldTime = 2f;
                shielded = false;
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        
    }
    /*void FixedUpdate()
    {
        if(nextPosition!=null)
        {
            transform.Translate((nextPosition.position - transform.position).normalized * speed * Time.fixedDeltaTime);
        }
        
    }*/
    
}
