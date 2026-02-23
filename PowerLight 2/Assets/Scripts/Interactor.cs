using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    public LayerMask interactable;
    public Transform interactorSource;
    public float InteractRange;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.OverlapSphere(interactorSource.position, 5f, interactable).Length > 0)
            {
                Physics.OverlapSphere(interactorSource.position, 5f, interactable)[0].GetComponent<Transform>().position = Vector3.zero;

            }
        }

    }



}
