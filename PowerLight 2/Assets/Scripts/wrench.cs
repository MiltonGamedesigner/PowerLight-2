using Unity.VisualScripting;
using UnityEngine;

public class wrench : MonoBehaviour
{
    private PlayerAttack player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerAttack>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 2 && Input.GetKeyDown(KeyCode.L))
        {
            player.HasWrench = true;
            gameObject.SetActive(false);
        }
    }
}
