using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshBaker : MonoBehaviour
{
    private NavMeshSurface navMesh;

    void Start()
    {
        navMesh = GetComponent<NavMeshSurface>();
        RealTimeBake();
    }

    void Update()
    {
        
    }

    private void RealTimeBake()
    {
        Debug.Log("Building NavMesh...");
        navMesh.BuildNavMesh();
    }
}
