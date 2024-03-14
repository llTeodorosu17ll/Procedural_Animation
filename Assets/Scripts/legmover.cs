using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class legmover : MonoBehaviour
{
    public Transform raycastpoint;
    public Transform target;
    public Vector3 restingposition;
    public LayerMask mask;
    public Vector3 newposition;
    public Transform steppingpoint;
    public bool leggrounded;
    public GameObject player;
    public float offset;
    public float movedistance;
    public static int currentmovevalue = 1;
    public int movevalue;
    public float speed = 10f;
    public legmover otherleg;
    public bool hasmoved;
    public bool moving;
    public bool movingdown;

    void Start()
    {
        restingposition = target.position;
        steppingpoint.position = new Vector3(restingposition.x * offset, restingposition.y, restingposition.x);
    }

    // Update is called once per frame
    void Update()
    {
        newposition = calculatepoint(steppingpoint.position);

        if (Vector3.Distance(restingposition, newposition) > movedistance || moving && leggrounded)
        {
            Step(newposition);
        }
        updateik();
    }

    public Vector3 calculatepoint(Vector3 position)
    {
        Vector3 dir = position - raycastpoint.position;
        RaycastHit hit;
        if(Physics.SphereCast(raycastpoint.position, 1f, dir, out hit, 5f, mask))
        {
            position= hit.point;
            leggrounded = true;
        }
        else
        {
            position = restingposition;
            leggrounded= false;
        }
        return position;
    }

    public void Step(Vector3 position)
    {
        if(currentmovevalue == movevalue)
        {
            leggrounded = false;
            hasmoved = false;
            moving = true;

            target.position = Vector3.MoveTowards(target.position, position + Vector3.up, speed * Time.deltaTime);
            restingposition = Vector3.MoveTowards(target.position, position + Vector3.up, speed * Time.deltaTime);
            if(target.position == Vector3.up)
            {
                movingdown= true;
            }
            if (movingdown = true)
            {
                target.position = Vector3.MoveTowards(target.position, position, speed* Time.deltaTime);
                restingposition = Vector3.MoveTowards(target.position, position, speed * Time.deltaTime);
            }
            if(target.position == position)
            {
                leggrounded= true;
                hasmoved= true;
                moving = false;
                movingdown= false;
                if(currentmovevalue == movevalue && otherleg.hasmoved == true)
                {
                    currentmovevalue = currentmovevalue * -1 + 3;
                }
            }
        } 
    }
    public void updateik()
    {
        target.position = restingposition;
    }
}
