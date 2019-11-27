using UnityEngine;

public class PlayerMotor : PlayerController
{
    private Vector3 move;
    private Vector3 velocity;
    private bool isGrounded;

    public void Move(float _forwardMovement, float _sidewaysMovement, bool jump, bool crouch)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        move = sidewaysMovement * Vector3.right + forwardMovement * Vector3.forward;

        controller.Move(move);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
