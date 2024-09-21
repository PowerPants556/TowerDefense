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
    [SerializeField] private GameObject planePrefab;
    [SerializeField] private GameObject cameraRotatePref;

    [Space(15)]
    [SerializeField] private Transform nodeParent;


    [ContextMenu("CreateNodes")]
    private void CreateNodes()
    {
        while (nodeParent.childCount > 0)
        {
            DestroyImmediate(nodeParent.GetChild(0).gameObject);
        }

        GameObject plane = Instantiate(planePrefab, new Vector3((NODE_GRID_ROW_COUNT * offset) / 2 - 0.75f, -0.5f, (NODE_GRID_COLLUM_COUNT * offset) / 2 - 0.75f), Quaternion.identity, nodeParent);
        plane.transform.localScale = new Vector3(0.1f * NODE_GRID_ROW_COUNT * offset -0.05f, plane.transform.localScale.y, 0.1f * NODE_GRID_COLLUM_COUNT * offset -0.05f);

        GameObject camRotat = GameObject.FindWithTag("CameraRotate");
        camRotat.transform.position = new Vector3((NODE_GRID_ROW_COUNT * offset) / 2 - 0.75f, -1.5f, (NODE_GRID_COLLUM_COUNT * offset) / 2 - 0.75f);

        for (int x = 0; x < NODE_GRID_ROW_COUNT; x++)
        {
            for(int z = 0; z <NODE_GRID_COLLUM_COUNT; z++)
            {
                GameObject obj = Instantiate(nodePrefab, new Vector3(x * offset, 0, z * offset), Quaternion.identity, nodeParent);
                obj.name = "Name: " + x + " " + z;
            }
        }
    }

    private void FixedUpdate()
    {
        GameObject camRotat = GameObject.FindWithTag("CameraRotate");

        if (Input.GetKey("a"))
        {
            camRotat.transform.Rotate(0f, 0f + 1f, 0f);
        }
        if (Input.GetKey("d"))
        {
            camRotat.transform.Rotate(0f, 0f + -1f, 0f);
        }
    } 
}
