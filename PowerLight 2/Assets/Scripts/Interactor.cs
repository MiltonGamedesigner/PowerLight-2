using UnityEngine;


public class Interactor : MonoBehaviour
{
    public int[] test;

    public LayerMask interactable;
    public Transform interactorSource;
    public float InteractRange;

    void Start()
    {
        //test[2] = 3;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.OverlapSphere(interactorSource.position, 5f, interactable).Length > 0)
            {
                Physics.OverlapSphere(interactorSource.position, 5f, interactable)[0].GetComponent<Interactable>().Interact();
            }
        }
    }



}
