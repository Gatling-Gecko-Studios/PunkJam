using System;
using UnityEngine;

namespace Code.GridSystem
{
    public class PlaceableObject : MonoBehaviour
    {
        public bool Placed { get; private set; }
        public Vector3Int Size { get; private set; }
        private Vector3[] Vertices;
        private MoneyManager _moneyManager;

        private void GetColliderVertexPositionsLocal()
        {
            BoxCollider b = gameObject.GetComponent<BoxCollider>();
            Vertices = new Vector3[4];
            Vertices[0] = b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f;
            Vertices[1] = b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f;
            Vertices[2] = b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
            Vertices[3] = b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;
        }

        private void CalculateSizeInCells()
        {
            Vector3Int[] vertices = new Vector3Int[Vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 worldPos = transform.TransformPoint(Vertices[i]);
                vertices[i] = BuildingSystem.current.gridLayout.WorldToCell(worldPos);
            }

            Size = new Vector3Int(Math.Abs((vertices[0] - vertices[1]).x),
                Math.Abs((vertices[0] - vertices[3]).y),
                1);
        }

        public Vector3 GetStartPosition()
        {
            return transform.TransformPoint(Vertices[0]);
        }

        private void Start()
        {
            GetColliderVertexPositionsLocal();
            CalculateSizeInCells();
            _moneyManager = FindObjectOfType<MoneyManager>();
        }

        public virtual void Place()
        {
            ObjectDrag drag = gameObject.GetComponent<ObjectDrag>();
            Destroy(drag);
            Placed = true;
            _moneyManager.UpdateGraveCount();
            //doe dingen als placed
        }
    }
}