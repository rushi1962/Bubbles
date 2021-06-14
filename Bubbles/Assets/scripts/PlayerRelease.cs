using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRelease : MonoBehaviour
{
    //public Transform currentTarget, nextTarget;
   // public GameObject player;
    public Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    public void Release()
    {
        player.release = true;
        if(GameManager.gm.firstTime&& GameManager.gm.tutorialText)
        {
            GameManager.gm.tutorialText.SetActive(false);
        }

    }
}
