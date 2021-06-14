using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour
{
    // Start is called before the first frame update
    public float Delay;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        Invoke("animatorExit",Delay-1f);
        
        Invoke("DestroyObject", Delay);
        
        
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    void animatorExit()
    {
        if (animator)
        {
            animator.SetTrigger("Exit");
        }
    }
}
