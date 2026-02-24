using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    private Vector2 move;
    private float _velocity;
    public Animator ani;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        S

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            ani.SetBool("isWalking", true);

        }

        else
        {

            ani.SetBool("isWalking", false);

        }

        // transform.Translate(movement * speed * Time.deltaTime, Space.World);
        Debug.Log(movement * speed);
        float gravity = rb.linearVelocity.y;
        rb.linearVelocity = (movement * speed) + new Vector3(0, gravity, 0);


    }
}
