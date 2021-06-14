using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public GameObject[] EnemyPrefabs;
    
    public GameObject GetEnemyPrefab(bool difficult)
    {
        int index;
        if (difficult)
        {
            index = Random.Range(13, EnemyPrefabs.Length - 1);
        }
        else
        {
            index = Random.Range(0, 12);
        }
        
        return EnemyPrefabs[index];
    }
}
