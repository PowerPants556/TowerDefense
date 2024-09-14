using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int NODE_GRID_ROW_COUNT = 4;
    [SerializeField] private int NODE_GRID_COLLUM_COUNT = 4;
    [Tooltip("Ofset between nodes")]
    [SerializeField] private float offset = 1.5f;

    [Space(15)]
    [Header("Prefabs: ")]
    [SerializeField] private GameObject nodePrefab;

    private void Start()
    {

    }
    
    [ContextMenu("CreateNodes")]
    private void CreateNodes()
    {
        if (transform.childCount > 0)
        {
            /*foreach(Transform child in transform.GetComponentsInChildren<Transform>())
            {
                DestroyImmediate(child);
            }*/
        }
        for (int x = 0; x < NODE_GRID_ROW_COUNT; x++)
        {
            for(int z = 0; z <NODE_GRID_COLLUM_COUNT; z++)
            {
                GameObject obj = Instantiate(nodePrefab, new Vector3(x * offset, 0, z * offset), Quaternion.identity, transform);
                obj.name = "Name: " + x + " " + z;
            }
        }
    }
}
