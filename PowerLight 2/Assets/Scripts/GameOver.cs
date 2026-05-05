using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject restartUI;
    bool canRestart;
    void Start()
    {
        StartCoroutine(RestartDelay());
    }

    IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(5);
        restartUI.SetActive(true);
        canRestart = true;
    }
    void Update()
    {
        if (canRestart && Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(1);
        }
    }
}
