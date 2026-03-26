using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float windUpTime;
    public BoxCollider weaponHitbox;
    public Animator ani;
    public GameObject wrench;
    public bool HasWrench;

    private bool startAttack;

    private void Start()
    {
        HasWrench = false;
    }
    void Update()
    {
        wrench.SetActive(HasWrench);

        if (!startAttack && Input.GetKeyDown(KeyCode.K) && HasWrench)
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
