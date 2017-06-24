using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTestHarness : MonoBehaviour {

    private Animator m_spiderAnimator;

	// Use this for initialization
	void Start () 
    {
        m_spiderAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        // Death
        if (Input.GetKey(KeyCode.Alpha6))
        {
            m_spiderAnimator.SetTrigger("death");

            // TDOO: This is just hack.  I was seeing a studdering of the animation and used this as a delay.  It appeared to work, but need to fix.
            for (int i = 0; i < 1000; i++)
            {
                Debug.Log(i.ToString());
            }

            return;
        }


        // Attack
        if (Input.GetKey(KeyCode.Alpha3))
        {
            m_spiderAnimator.SetInteger("attack", 1);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            m_spiderAnimator.SetInteger("attack", 2);
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            m_spiderAnimator.SetInteger("attack", 3);
        }
        else
        {
            m_spiderAnimator.SetInteger("attack", 0);
        }

        // Movement
        if (Input.GetKey(KeyCode.Alpha2))
        {
            m_spiderAnimator.SetInteger("move", 2);
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            m_spiderAnimator.SetInteger("move", 1);
        }
        else
        {
            m_spiderAnimator.SetInteger("move", 0);
        }

        //Debug.Log(m_spiderAnimator.GetInteger("walk").ToString());

	}
}
