using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woon : MonoBehaviour
{
    public static woon Instance;
    public GameObject[] Joints;
    public Vector3 Center;
    public SkinnedMeshRenderer SMRenderer;
    public Mesh woonBakedMesh;
    Vector3 velocity;

    void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < Joints.Length; i++)
        {
            Center += Joints[i].transform.position;
        }

        Center = Center / Joints.Length;
        transform.position = Center;
        Center = Vector3.zero;
    }

    void WoonBakedMeshToCollider()
    {
        SMRenderer.BakeMesh(woonBakedMesh);
        gameObject.GetComponent<MeshCollider>().sharedMesh = woonBakedMesh;
    }
}
