using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float angspeed;
    private float movx;
    public float movy;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public static Controller instance;

    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        movx = Input.GetAxis("Horizontal");
        movy = Input.GetAxis("Vertical");

        if (movx != 0)
        {
            Vector3 movement = transform.right * movx * speed * Time.deltaTime;
            rb.velocity = movement;
        }

        transform.Rotate(0, movx * angspeed * Time.deltaTime, 0);
    }
}
