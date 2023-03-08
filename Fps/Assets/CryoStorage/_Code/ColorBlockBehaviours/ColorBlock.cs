using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorBlock : ColoredObject
{
    [SerializeField] private GameObject moveTarget;
    [SerializeField] private float lerpSpeed = 2f;
    private Vector3 _moveTargetPos;
    private Vector3 _startPos;
    public UnityEvent onHit;
    protected override void Start()
    {
        Prepare();
        base.Start();
        _startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<ColorBall>()) return;
        ColorBall colorBall = collision.gameObject.GetComponent<ColorBall>();
        if (colorBall.color == color)
        {
            onHit.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(moveTarget.transform.position, .3f);
        Gizmos.DrawLine(transform.position,moveTarget.transform.position);
    }

    public void MoveToTarget()
    {
        StopAllCoroutines();
        StartCoroutine(LerpPosition(_moveTargetPos, lerpSpeed));
    }

    public void ResetPos()
    {
        StopAllCoroutines();
        StartCoroutine(LerpPosition(_startPos, lerpSpeed));
    }

    public IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float timeElapsed = 0f;
        Vector3 startingPosition = transform.position;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure that the object's position is exactly equal to the target position once the lerp has finished
        transform.position = targetPosition;
    }

    protected override void Prepare()
    {
        _moveTargetPos = moveTarget.transform.position;
        base.Prepare();
    }
}
