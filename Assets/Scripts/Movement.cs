using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private const int WALKSPEED = 2;
    private const int RUNSPEED = 5;
    private const int ROTATIONSPEED = 100;
    private Animator m_animator;

    void Start()
    {
        m_animator = this.GetComponent<Animator>();
    }

    void Update() 
    {
        // Perform movement.
        float movementSpeed = WALKSPEED;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = RUNSPEED;
        }

        float translation = Input.GetAxis("Vertical") * movementSpeed;
        float rotation = Input.GetAxis("Horizontal") * ROTATIONSPEED;
        float strafe = Input.GetAxis("Strafe") * movementSpeed;
        
        // If left & right mouse buttons are down, then calculate translate and rotate via mouse.
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            translation = movementSpeed;
            rotation = Mathf.Clamp(Input.GetAxis("Mouse X"), -5.0f, 5.0f) * ROTATIONSPEED;
        }

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);
        transform.Rotate(0, rotation, 0);

        // Set Animation for movement above.
        if (Mathf.Abs(translation) > 0 || Mathf.Abs(rotation) > 0 || Mathf.Abs(strafe) > 0)
        {
            int animationMovementSpeed = 1;
            if (movementSpeed == RUNSPEED)
            {
                animationMovementSpeed = 2;
            }

            m_animator.SetInteger("move", animationMovementSpeed);
        }
        else
        {
            m_animator.SetInteger("move", 0);
        }
    }
}
