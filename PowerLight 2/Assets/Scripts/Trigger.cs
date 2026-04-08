using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isActivatable;

    public GameObject[] enable;
    public GameObject[] disable;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isActivatable)
        {
            Triggered();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (isActivatable && Input.GetKeyDown(KeyCode.L))
        {
            Triggered();
        }
    }

    private void Triggered()
    {
        foreach (GameObject go in enable)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in disable)
        {
            go.SetActive(false);
        }
    }
}
