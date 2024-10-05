using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float range = 2f;

    [Header("Bullet settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] gunBarrel;
    [SerializeField] private float rechargeTime;
    private List<Transform> targetInRange = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Start()
    {
        //InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
    private Transform FindTarget()
    {
        if (targetInRange == null) return null;
        Transform newTarget = targetInRange.First();

        //RemoveNullObjects();
        foreach(Transform t in targetInRange)
        {
            if(t == null)
            {
                continue;
            }
            float distanceToEnemy = Vector3.Distance(transform.position, t.position);
            float distanceToPrevEnemy = Vector3.Distance(transform.position, newTarget.position);
            if (distanceToEnemy < distanceToPrevEnemy)
            {
                target = t;
            }
        }
        return newTarget;
    }

    private void RemoveNullObjects()
    {
        var nullObjects = new List<Transform>();
        foreach(Transform t in targetInRange)
        {
            if(t == null)
            {
                nullObjects.Add(t);
            }            
        }
        foreach(Transform t in nullObjects)
        {
            targetInRange.Remove(t);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            targetInRange.Add(col.transform);
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
            target = FindTarget();
        }
    }
}
