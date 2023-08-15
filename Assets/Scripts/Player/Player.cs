using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;//0:Left 1:Middle 2:Right
    public float laneDistance = 7.5f;

    public float jumpForce;
    public float gravity = -20;

    private bool isDead = false;




    private bool isSliding = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {

        if (isDead)
            return;

        if (!PlayerManager.isGameStarted)

            return;

       // animator.SetBool("isGameStarted", true);

        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;


        direction.z = forwardSpeed;

        if (controller.isGrounded)
        {
            direction.y = -1;
            if (SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow))
            {
                //animator.SetBool("isGrounded", false);
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
            //animator.SetBool("isGrounded", true);
        }

        if (SwipeManager.swipeDown || Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }

        }
        if (SwipeManager.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }

        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //transform.position = targetPosition;
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
            {
                controller.Move(diff);
            }
        }

        //controller.center = controller.center;

        controller.Move(direction * Time.deltaTime);
    }



    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            Death();
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
    private IEnumerator Slide()
    {
        isSliding = true;
       // animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.2f, 0);
        controller.height = 0;
        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 0.9999f;

       // animator.SetBool("isSliding", false);
        isSliding = false;
    }
}
