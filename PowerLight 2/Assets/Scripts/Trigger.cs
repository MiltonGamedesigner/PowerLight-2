using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isActivatable;

    private bool inside;

    public GameObject[] enable;
    public GameObject[] disable;


    public void Update()
    {

        if (isActivatable && inside && Input.GetKeyDown(KeyCode.L))
        {
            Triggered();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isActivatable)
        {
            Triggered();
        }
        inside = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inside = false;
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
