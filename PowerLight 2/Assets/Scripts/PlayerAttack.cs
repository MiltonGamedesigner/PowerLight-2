using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float windUpTime;
    public BoxCollider weaponHitbox;
    public Animator ani;

    private bool startAttack;
    void Start()
    {

    }
    void Update()
    {
        if (!startAttack && Input.GetKeyDown(KeyCode.K))
        {
            startAttack = true;
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        GetComponent<PlayerMovement>().canMove = false;
        ani.SetTrigger("Attack");
       
        yield return new WaitForSeconds(windUpTime);

        weaponHitbox.enabled = true;

        yield return new WaitForSeconds(1.667f - windUpTime);
        
        startAttack = false;
        weaponHitbox.enabled = false;
        GetComponent<PlayerMovement>().canMove = true;
    }
}
