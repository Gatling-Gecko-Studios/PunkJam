using System;
using UnityEngine;

namespace Code.GridSystem
{
    public class ObjectDrag : MonoBehaviour
    {
        private Vector3 offset;

        private void OnMouseDown()
        {
            offset = transform.position - BuildingSystem.GetMouseWorldPosition();
        }

        private void OnMouseDrag()
        {
            Vector3 pos = BuildingSystem.GetMouseWorldPosition() + offset;
            transform.position = BuildingSystem.current.SnapCoordinateToGrid(pos);
        }
    }
}