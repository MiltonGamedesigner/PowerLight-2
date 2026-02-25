using System.Collections;
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
        if (Camera != null)
            StartCoroutine(CameraCutscene());
        Debug.Log("funkar");
    }
    public IEnumerator CameraCutscene()
    {
        Camera.Priority = 10;
        yield return new WaitForSeconds(5);
        Camera.Priority = 0;
    }
}
