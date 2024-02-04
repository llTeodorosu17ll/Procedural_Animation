using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Animator walkingFBAnim; // walk fwd and back
    [SerializeField] private Animator walkingLRAnim; // walk left and right
    [SerializeField] private Vector3 moveVector;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float jumpPower;

    private bool isGrounded;

    // Adjust the speed for the application.
    public float speed = 10.0f;

    // The target (cylinder) position.
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.velocity = Vector3.fwd;
            //walkingFBAnim.SetBool("Walking", true);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            rigidbody.velocity = Vector3.back;
            //walkingFBAnim.SetBool("Walking", true);
        } else if (Input.GetKeyDown(KeyCode.L))
        {
            rigidbody.velocity = Vector3.left;
            //walkingLRAnim.SetBool("Walking", true);
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            rigidbody.velocity = Vector3.right;
            //walkingLRAnim.SetBool("Walking", true);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
            walkingFBAnim = null;
            walkingLRAnim = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


