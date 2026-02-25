using Unity.Cinemachine;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject Object;
    public bool On;
    public string aniName;
    public CinemachineCamera Camera;

    public void Interact()
    {
        Camera.Priority = 10;




    }

}
