using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntered : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerDead;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player"&& !other.gameObject.GetComponent<Player>().dead&& !other.gameObject.GetComponent<Player>().shielded)
        {
            other.gameObject.GetComponent<Player>().dead = true;
            StartCoroutine(KillPlayer(other.gameObject));
        }
    }
    IEnumerator KillPlayer(GameObject playerObject)
    {
        yield return new WaitForSeconds(0.2f);
        playerObject.transform.GetChild(0).gameObject.SetActive(false);
        
        Instantiate(playerDead, playerObject.gameObject.transform.position, playerObject.gameObject.transform.rotation);
    }
}
