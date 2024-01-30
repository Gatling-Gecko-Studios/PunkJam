using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.GridSystem
{
    public class BuildingSystem : MonoBehaviour
    {
        public static BuildingSystem current;

        public GridLayout gridLayout;
        private Grid grid;
        [SerializeField] private Tilemap MainTilemap;
        [SerializeField] private TileBase whiteTile;

        public GameObject prefab1;
        public GameObject prefab2;

        private PlaceableObject objectToPlace;

        #region Unity Methods

        private void Awake()
        {
            current = this;
            grid = gridLayout.gameObject.GetComponent<Grid>();
        }

        #endregion

        #region Utils

        public static Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                return raycastHit.point;
            }
            else
            {
                return Vector3.zero;
            }
        }

        public Vector3 SnapCoordinateToGrid(Vector3 position)
        {
            Vector3Int cellPos = gridLayout.WorldToCell(position);
            position = grid.GetCellCenterWorld(cellPos);
            return position;
        }

        #endregion

        #region Building Placement

        public void InitialiseWithObject(GameObject prefab)
        {
            Vector3 position = SnapCoordinateToGrid(Vector3.zero);

            GameObject obj = Instantiate(prefab, position, quaternion.identity);
            objectToPlace = obj.GetComponent<PlaceableObject>();
            obj.AddComponent<ObjectDrag>();
        }

        #endregion
    }
}