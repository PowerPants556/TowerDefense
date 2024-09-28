using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float range = 2f;

    private List<Transform> targetInRange = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
    private void FindTarget()
    {
        if (targetInRange == null) return;
        float distance = 0;

        foreach(Transform t in targetInRange)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, t.position);
            if (distanceToEnemy < distance)
            {
                distance = distanceToEnemy;
                target = t;
            }
        }

        if (distance > range)
        {
            target = null;
            return;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            targetInRange.Add(target.transform);
        }
    }
    private void OnTraggerExit(Collider col)
    {
        if(col.tag == "Enemy")
        {
            targetInRange.Remove(col.transform);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if(col.tag == "Enemy")
        {
            FindTarget();
        }
    }
}
