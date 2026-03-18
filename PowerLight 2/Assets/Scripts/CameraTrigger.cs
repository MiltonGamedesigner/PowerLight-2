using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (CameraTrigger ct in FindObjectsByType<CameraTrigger>(FindObjectsSortMode.None))
            {
                ct.DisableParent();
            }

            transform.parent.GetComponentInChildren<CinemachineCamera>().Priority = 10;
        }
    }

    public void DisableParent()
    {

        transform.parent.GetComponentInChildren<CinemachineCamera>().Priority = 0;
    }
}
