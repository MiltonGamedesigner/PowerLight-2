using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public enum EnemyStates { idle, aggresive, attacking }

    public float health;
    public float idleWait;
    public float detectDistance;
    public float AttackRange;
    public float windUpTime;

    public GameObject weaponHitbox1;
    public GameObject weaponHitbox2;
    public Transform[] pursuitPoints;
    public LayerMask layer;
    public Animator animator;
    public Material hurt;
    public Material idle;

    private Transform player;
    private NavMeshAgent agent;
    private int nextPursuit;
    public EnemyStates state;
    private float attackBuffer;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyStates.idle;
        nextPursuit = 0;
        agent.SetDestination(pursuitPoints[nextPursuit].transform.position);
        player = FindFirstObjectByType<PlayerMovement>().transform;
        animator.SetBool("Walk", true);
    }
    void Update()
    {
        attackBuffer -= Time.deltaTime;
        if (state == EnemyStates.idle)
        {
            Idle();
        }
        if (state == EnemyStates.aggresive)
        {
            Aggresive();
        }
        if (state == EnemyStates.attacking)
        {
            if (attackBuffer < 0)
            {
                state = EnemyStates.aggresive;
            }
        }
    }

    public void Aggresive()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, player.position - transform.position, out hit, detectDistance, layer))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                agent.SetDestination(player.position);
            }
            else
            {
                state = EnemyStates.idle;
            }
        }
        if (Vector3.Distance(transform.position, agent.destination) <= AttackRange)
        {
            Debug.Log("funkar");
            attackBuffer = 3;
            StartCoroutine(Attack());
        }
    }
    public void Idle()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, transform.forward, out hit, detectDistance, layer))
        {
            Debug.DrawLine(transform.position + Vector3.up * 0.5f, hit.point);
            if (hit.collider.gameObject.tag == "Player")
            {
                state = EnemyStates.aggresive;
                return;
            }
        }

        if (Vector3.Distance(transform.position, pursuitPoints[nextPursuit].transform.position) < 0.4f)
        {
            nextPursuit++;

            if (nextPursuit == pursuitPoints.Length)
            {
                nextPursuit = 0;
            }

            StartCoroutine(ChangeDestination());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            StartCoroutine(Hurt());
        }
    }


    IEnumerator ChangeDestination()
    {
        animator.SetBool("Walk", false);
        yield return new WaitForSeconds(idleWait);
        animator.SetBool("Walk", true);

        agent.SetDestination(pursuitPoints[nextPursuit].transform.position);
    }
    IEnumerator Attack()
    {
        state = EnemyStates.attacking;
        agent.SetDestination(transform.position);
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(windUpTime);

        weaponHitbox1.SetActive(true);
        weaponHitbox2.SetActive(true);

        yield return new WaitForSeconds(1.93f - windUpTime);

        weaponHitbox1.SetActive(false);
        weaponHitbox2.SetActive(false);

    }
    IEnumerator Hurt()
    {
        health--;
        GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial = hurt;
        yield return new WaitForSeconds(0.25f);
        GetComponentInChildren<SkinnedMeshRenderer>().sharedMaterial = idle;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
