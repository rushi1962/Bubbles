using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReached : MonoBehaviour
{
    // Start is called before the first frame update
    public TargetManager targetManager;
    public Transform player;
    public bool reached;
    public GameObject light;
    public GameObject thisWheel;
    public EnemyScriptableObject enemyScriptableObject;
    void Start()
    {
        targetManager = GameObject.FindGameObjectWithTag("TargetManager").GetComponent<TargetManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        reached = false;
        StartCoroutine(InstantitateEnemyWheel( 0f));
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(transform.position,player.position)<0.01f&&!reached )
        {
            print("Reached");
            reached = true;
            GameObject newTarget = targetManager.targets[0];
            targetManager.targets.RemoveAt(0);
            if(thisWheel)
            {
                Destroy(thisWheel);
                
            }
            GameManager.gm.points++;
            newTarget.SetActive(true);
            newTarget.GetComponent<PlayerReached>().reached = false;
            
            targetManager.targets.Insert(targetManager.targets.Count, newTarget);
            Vector3 newPosition= targetManager.targets[targetManager.targets.Count - 2].transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 4.75f, 0f);
            if (newPosition.x < -2f || newPosition.x > 2f)
            {
                newPosition = new Vector3(1f, newPosition.y, 0f);
            }
            targetManager.targets[targetManager.targets.Count - 1].transform.position = newPosition;
           // if(!newTarget.GetComponent<PlayerReached>().thisWheel)
           // {
               // newTarget.GetComponent<PlayerReached>().thisWheel=newTarget.GetComponent<PlayerReached>().InstantitateEnemyWheel(newPosition);
            //}
            
            // player.gameObject.GetComponent<Player>().levels++;
            player.gameObject.GetComponent<Player>().nextPosition = targetManager.targets[4].transform;
            player.gameObject.GetComponent<Player>().release = false;
            gameObject.GetComponent<Animator>().SetTrigger("Reached");
            Instantiate(light,transform.position,transform.rotation);
        }
        if(reached&& Vector3.Distance(transform.position, player.position)>0.5f)
        {
            print("Exit");
            reached = false;
            if(!thisWheel)
            {
                StartCoroutine(InstantitateEnemyWheel(5f));
            }
        }

    }
    
    IEnumerator InstantitateEnemyWheel( float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        GameObject newWheel;
        if (GameManager.gm.points<=10)
        {
             newWheel = Instantiate(enemyScriptableObject.GetEnemyPrefab(false), transform.position, transform.rotation);
        }
         else
        {
             newWheel = Instantiate(enemyScriptableObject.GetEnemyPrefab(true), transform.position, transform.rotation);
        }
         thisWheel = newWheel;
         newWheel.transform.parent=this.gameObject.transform;
    }
}
