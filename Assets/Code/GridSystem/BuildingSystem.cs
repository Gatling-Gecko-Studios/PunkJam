using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
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

        public GameObject CryptPrefab;
        public GameObject CoffinPrefab;
        public GameObject GraveStonePrefab;
        public GameObject FountainPrefab;
        public GameObject BushPrefab;
        public GameObject IronFencePrefab;
        public GameObject BrickWallPrefab;
        public GameObject currentDraggedObject;

        private PlaceableObject objectToPlace;
        private float rotationOffset;

        #region Unity Methods

        private void Awake()
        {
            current = this;
            grid = gridLayout.gameObject.GetComponent<Grid>();
        }

        private void Update()
        {
            if (!objectToPlace) return;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                if (CanBePlaced(objectToPlace))
                {
                    objectToPlace.Recalculate();
                    Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
                    TakeArea(start, objectToPlace.Size);
                    PlaceCurrentObject();
                }
                else
                {
                    CancelPlacement();
                }
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(objectToPlace.gameObject);
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                rotationOffset += 90f;
                currentDraggedObject.gameObject.transform.rotation = Quaternion.identity;
                currentDraggedObject.gameObject.transform.Rotate(0, rotationOffset, 0);
            }
        }

        #endregion

        #region Utils

        public static Vector3 GetMouseWorldPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 10000f, LayerMask.GetMask("Default")))
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

        private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
        {
            TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
            int counter = 0;

            foreach (var v in area.allPositionsWithin)
            {
                Vector3Int pos = new Vector3Int(v.x, v.y, 0);
                array[counter] = tilemap.GetTile(pos);
                counter++;
            }

            return array;
        }

        #endregion

        #region Building Placement

        public void PlaceCurrentObject()
        {
            currentDraggedObject.GetComponent<PlaceableObject>().Place();
            currentDraggedObject = null;
            objectToPlace = null;
        }

        public void CancelPlacement()
        {
            if(objectToPlace != null)
            {
                Destroy(objectToPlace.gameObject);
            }
            objectToPlace = null;
            currentDraggedObject = null;
        }

        public void HoldPlaceableObject(GameObject prefab)
        {
            //Vector3 position = SnapCoordinateToGrid(Vector3.zero);
            GameObject obj = Instantiate(prefab, GetMouseWorldPosition(), quaternion.identity, GameObject.FindGameObjectWithTag("GraveContainer").transform);
            objectToPlace = obj.GetComponent<PlaceableObject>();
            obj.AddComponent<ObjectDrag>();
            Destroy(currentDraggedObject);
            currentDraggedObject = obj;
            currentDraggedObject.gameObject.transform.rotation = Quaternion.identity;
            currentDraggedObject.gameObject.transform.Rotate(0, rotationOffset, 0);
        }

        private bool CanBePlaced(PlaceableObject placeableObject)
        {
            if (placeableObject.cost > MoneyManager.currentMoney)
            {
                Debug.Log("Not enough money.");
                PlayErrorSound();
                return false;
            }
            return true; //didnt want to deal with buggy cell calcs;

            BoundsInt area = new BoundsInt();
            area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
            area.size = placeableObject.Size;
            //area.size = new Vector3Int(area.size.x + 1, area.size.y + 1, area.size.z);
            TileBase[] baseArray = GetTilesBlock(area, MainTilemap);
            foreach (var b in baseArray)
            {
                if (b == whiteTile)
                {
                    Debug.Log("cannot be placed here.");
                    PlayErrorSound();
                    return false;
                }  
            }

            return true;
        }

        private void PlayErrorSound()
        {
            FindObjectOfType<DayAudioManager>().PlayPlaceErrorSound();
        }

        public void TakeArea(Vector3Int start, Vector3Int size)
        {
            MainTilemap.BoxFill(start, whiteTile, start.x, start.y, start.x + size.x, start.y + size.y);
        }

        #endregion
    }
}