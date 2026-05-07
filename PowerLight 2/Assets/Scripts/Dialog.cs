using System.ComponentModel;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TMP_Text textObject;
    [TextArea(15, 20)]
    public string text;
     bool entered;

    PlayerMovement player;


    private void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if(entered && Input.GetKeyDown(KeyCode.L))
        {
            textObject.text = "";
            player.canMove = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.canMove = false;
            entered = true;
            textObject.text = text;
        }
    }
}
