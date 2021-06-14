using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public GameObject targetPrefab;
    public int listLength;
    public Vector3 firstPosition;
    void Start()
    {
        targets = new List<GameObject>();
        for (int i = 0; i < listLength; i++)
        {

            GameObject newGameObject = Instantiate(targetPrefab, transform.position, transform.rotation) as GameObject;
            newGameObject.name = "Target"+i;
            targets.Insert(0, newGameObject);
        }
        for(int i = 0; i < listLength; i++)
        {
            if(i==0)
            {
                targets[i].transform.position = firstPosition;
            }
            else
            {
                Vector3 newPosition= targets[i - 1].transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 4.75f, 0f);
                if(newPosition.x<-2f||newPosition.x>2f)
                {
                    newPosition = new Vector3(1f,newPosition.y,0f);
                }
                targets[i].transform.position = newPosition;
            }
            
        }
        for (int i = 0; i < listLength; i++)
        {
            if (i < 4)
            {
                targets[i].SetActive(false);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
