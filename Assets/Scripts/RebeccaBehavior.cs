using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RebeccaBehavior : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(target.transform.position.x - agent.transform.position.x) > 3
            || Mathf.Abs(target.transform.position.z - agent.transform.position.z) > 3)
        {
            if (agent.enabled)
            {

                agent.SetDestination(target.transform.position);

                anim.SetBool("isWalking", true);
            }
        }



        // Check if we've reached the destination
        // if (!agent.pathPending)

        {
            if (agent.remainingDistance - 1 <= agent.stoppingDistance)
            {
                /*   anim.SetBool("isWalking", false);
                 anim.SetBool("isIdle", true);*/
                if (agent.velocity.sqrMagnitude == 0f)
                {  // Done

                    anim.SetBool("isWalking", false);

                }

            }
        }
    }
}
