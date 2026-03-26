using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float iFrames;
    public float time;

    public ParticleSystem ps;
    void Start()
    {
        ps.Stop();
    }
    void Update()
    {
        iFrames += Time.deltaTime;
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHit" && iFrames > time)
        {
            health--;
            StartCoroutine(particle());
            time = Time.time + 1;
        }
    }
    IEnumerator particle()
    {
        ps.Play();
        yield return new WaitForSeconds(1);
        ps.Stop();
    }
}
