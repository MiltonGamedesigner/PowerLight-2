using UnityEngine;

public class wrench : MonoBehaviour
{
    private PlayerAttack player;
    public float pickUpDistance;
    void Start()
    {
        player = FindFirstObjectByType<PlayerAttack>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= pickUpDistance && Input.GetKeyDown(KeyCode.L))
        {
            player.HasWrench = true;
            gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, pickUpDistance);
    }
}
