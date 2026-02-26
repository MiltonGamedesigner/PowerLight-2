using UnityEngine;


public class Interactor : MonoBehaviour
{
    public int Progression;

    public float distance;
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
            if (Physics.OverlapSphere(interactorSource.position, distance, interactable).Length > 0)
            {
                foreach (Collider col in Physics.OverlapSphere(interactorSource.position, distance, interactable))
                {
                    if (col.GetComponent<Interactable>().phase == Progression)
                    {
                        col.GetComponent<Interactable>().Interact();
                        Progression++;
                    }
                }
            }
        }
    }



}
