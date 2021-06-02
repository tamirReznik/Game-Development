using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalkingBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject target;
    public Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            if (Mathf.Abs(newPos.x - agent.transform.position.x) > 3
            || Mathf.Abs(newPos.z - agent.transform.position.z) > 3)
            {

                agent.SetDestination(newPos);
                /* agent.SetDestination(target.transform.position);
                 Debug.Log("check dist");
                 Debug.Log(target.transform.position.sqrMagnitude);*/
                // anim.SetBool("isWalking", true);
            }


            if (agent.velocity.sqrMagnitude == 0f)
            {  // Done
               //  if (/*anim.GetCurrentAnimatorStateInfo(0).IsName("Brutal To Happy Walking")
               // || * anim.GetCurrentAnimatorStateInfo(0).IsName("Breathing Idle"))
               //  {
               // Debug.Log(anim.GetAnimatorTransitionInfo(0).nameHash);

                newPos = RandomNavSphere(transform.position, 150, -1);
                // Avoid any reload.
                //  }
                // newPos = RandomNavSphere(transform.position, 150, -1);
                //anim.SetBool("isWalking", false);

            }
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
