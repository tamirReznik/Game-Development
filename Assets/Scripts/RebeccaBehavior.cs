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

        agent.SetDestination(target.transform.position);

        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);

        // Check if we've reached the destination
        // if (!agent.pathPending)
        {
            //  if (agent.remainingDistance <= agent.stoppingDistance)
            {
                /*   anim.SetBool("isWalking", false);
                 anim.SetBool("isIdle", true);*/
                if (agent.velocity.sqrMagnitude == 0f)
                {  // Done
                   //  Debug.Log("<color=red>Error: </color>AssetBundle not found");
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", true);

                }

            }
        }
    }
}
