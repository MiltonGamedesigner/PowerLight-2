using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public enum EnemyStates { idle, aggresive }
    public Transform[] pursuitPoints;
    public float idleWait;
    public Animator animator;

    private NavMeshAgent agent;
    private int currentDestination;
    private EnemyStates state;
    private bool setNext;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStates.idle;
        currentDestination = 0;
        agent.SetDestination(pursuitPoints[currentDestination].transform.position);
    }
    void Update()
    {
        if (state == EnemyStates.idle)
        {
            Idle();
        }
    }
    public void Idle()
    {
        if (Vector3.Distance(transform.position, pursuitPoints[currentDestination].transform.position) < 0.4f)
        {
            currentDestination++;

            if (currentDestination == pursuitPoints.Length)
            {
                currentDestination = 0;
            }

            StartCoroutine(ChangeDestination());
        }

    }

    IEnumerator ChangeDestination()
    {
        animator.SetBool("Walk", false);
        yield return new WaitForSeconds(idleWait);
        animator.SetBool("Walk", true);

        agent.SetDestination(pursuitPoints[currentDestination].transform.position);
    }
}
