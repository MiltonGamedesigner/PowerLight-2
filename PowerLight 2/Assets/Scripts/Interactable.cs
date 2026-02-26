using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject Object;
    public float cameraTime;
    public bool On;
    public string aniName;
    public Animator animator;
    public CinemachineCamera Camera;

    public void Interact()
    {
        if (Camera != null)
            StartCoroutine(CameraCutscene());

        animator.SetBool(aniName, true);
    }
    public IEnumerator CameraCutscene()
    {
        Camera.Priority = 10;
        yield return new WaitForSeconds(cameraTime);
        Camera.Priority = 0;
    }
}
