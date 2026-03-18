using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed;
    public float moveSpeedBack;
    public float rotateSpeed;
    float movement;
    float rotation;

    public Animator anim; //animation

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = Input.GetAxis("Vertical");

        movement *= (movement > 0) ? moveSpeed : moveSpeedBack;

        rotation = Input.GetAxis("Horizontal") * rotateSpeed;

        //Vector3 vel = transform.forward * movement;

        //rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
        //transform.Rotate(0f, rotation, 0f);

        if (movement > 0)
        {

            anim.SetBool("isWalking", true);

        }
        else if (movement < 0)
        {
            anim.SetBool("isWalkingBack", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBack", false);

            if (rotation != 0)
            {
                anim.SetBool("isWalking", true);
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 vel = transform.forward * movement;

        rb.linearVelocity = new Vector3(vel.x, rb.linearVelocity.y, vel.z);
        transform.Rotate(0f, rotation, 0f);
    }
}
