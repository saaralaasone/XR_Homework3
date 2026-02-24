using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    //animation
    [SerializeField] private float speed;
    private Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";

    //physics movement
    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;

    void Start()
    {
        //animation
        animator = GetComponent<Animator>();

        //physics movement
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        //teleport hands
        body.position = followTarget.position;
        body.rotation = followTarget.rotation;

        body.isKinematic = true;
        body.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        //position
        /*
        var positionWithOffset = followTarget.TransformPoint(positionOffset); //followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);
        */
        var targetPos = followTarget.TransformPoint(positionOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        //rotation
        /*
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        if (Mathf.Abs(axis.magnitude)!=Mathf.Infinity)
        {
            if (angle>180.0f) { angle -= 360.0f; }
            body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
        }*/
        var targetRot = followTarget.rotation * Quaternion.Euler(rotationOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRot, followSpeed * Time.deltaTime);

    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }
}
