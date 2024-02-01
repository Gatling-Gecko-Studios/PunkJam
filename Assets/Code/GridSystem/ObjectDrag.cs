using System;
using UnityEngine;

namespace Code.GridSystem
{
    public class ObjectDrag : MonoBehaviour
    {
        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - BuildingSystem.GetMouseWorldPosition();
        }

        private void Update()
        {
            Vector3 pos = BuildingSystem.GetMouseWorldPosition();
            transform.position = BuildingSystem.current.SnapCoordinateToGrid(pos);
        }
    }
}