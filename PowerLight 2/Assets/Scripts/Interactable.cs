using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int phase;

    public float cameraTime;
    public string aniName;
    public Animator animator;
    public CinemachineCamera Camera;
    public Transform teleporter;
    public Vector3 destination;

    public void Interact()
    {
        if (Camera != null)
            StartCoroutine(CameraCutscene());

        if (animator != null)
            animator.SetBool(aniName, true);

        if (teleporter != null)
            teleporter.position = destination;
    }

    public IEnumerator CameraCutscene()
    {
        Camera.Priority = 10;
        yield return new WaitForSeconds(cameraTime);
        Camera.Priority = 0;
    }
}
