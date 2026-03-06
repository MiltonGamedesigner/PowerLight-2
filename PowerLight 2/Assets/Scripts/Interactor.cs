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
        Collider[] ínteractables = Physics.OverlapSphere(interactorSource.position, distance, interactable);

        if (!Input.GetKeyDown(KeyCode.E)) return;

        if (ínteractables.Length <= 0) return;

        foreach (Collider col in ínteractables)
        {
            Interactable inter = col.GetComponent<Interactable>();

            if (inter.phase != Progression) continue;

            inter.Interact();

            if (inter.isProgression)
            {
                Progression++;
            }
        }
    }



}
