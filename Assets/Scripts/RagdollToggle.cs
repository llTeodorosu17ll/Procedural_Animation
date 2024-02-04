using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollToggle : MonoBehaviour
{
    protected Animator Animator;
    protected Rigidbody Rigidbody;
    protected BoxCollider BoxCollider;
    //protected Spider Spider;

    protected Collider[] ChildrenCollider;
    protected Rigidbody[] ChildrenRigidbody;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Rigidbody= GetComponent<Rigidbody>();
        BoxCollider= GetComponent<BoxCollider>();
        //Spider = GetComponent<Spider>();

        ChildrenCollider = GetComponentsInChildren<Collider>();
        ChildrenRigidbody = GetComponentsInChildren<Rigidbody>();
    }

    void Start()
    {
        RagdollActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RagdollActive(bool active)
    {
        //children
        foreach(var collider in ChildrenCollider)
            collider.enabled = !active;
        foreach (var rigidbody in ChildrenRigidbody)
        {
            Rigidbody.detectCollisions= active;
            Rigidbody.isKinematic=!active;
        }
        //root
        Animator.enabled = !active;
        Rigidbody.detectCollisions= !active;
        Rigidbody.isKinematic = active;
        BoxCollider.enabled= !active;
        //Spider.enabled = !active;
    }

    
}
