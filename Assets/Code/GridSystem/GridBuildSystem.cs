using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace Code.GridSystem
{
    public class GridBuildSystem : MonoBehaviour
    {
        public static GridBuildSystem current;
        
        public GridLayout gridLayout;
        public Tilemap mainTilemap;
        public Tilemap tempTilemap;

        private static Dictionary<TileType, TileBase> _tileBases = new Dictionary<TileType, TileBase>();

        private Building temp;
        private Vector3 prevPos;
        private BoundsInt prevArea;
        
        #region UnityMethods

        private void Awake()
        {
            current = this;
        }

        private void Start()
        {
            string tilePath = @"Tiles\";
            _tileBases.Add(TileType.Empty, null);
            _tileBases.Add(TileType.White, Resources.Load<TileBase>(tilePath + "white"));
            _tileBases.Add(TileType.Green, Resources.Load<TileBase>(tilePath + "green"));
            _tileBases.Add(TileType.Red, Resources.Load<TileBase>(tilePath + "red"));
        }

        private void Update()
        {
            if (!temp) return;
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject(0))
                {
                    return;
                }

                if (!temp.Placed)
                {
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3Int cellPos = gridLayout.LocalToCell(touchPos);
                    if (prevPos != cellPos)
                    {
                        temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos + new Vector3(0f,0f,.0f));
                        prevPos = cellPos;
                        FollowBuilding();
                    }
                }
            }
        }

        #endregion

        #region TilemapManagement

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

        private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
        {
            int size = area.size.x * area.size.y * area.size.z;
            TileBase[] tileArray = new TileBase[size];
            FillTiles(tileArray, type);
            tilemap.SetTilesBlock(area, tileArray);
        }

        private static void FillTiles(TileBase[] arr, TileType type)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = _tileBases[type];
            }
        }
        
        #endregion

        #region BuildingPlacement

        public void InitialiseWithBuilding(GameObject building)
        {
            temp = Instantiate(building, Vector3.zero, quaternion.identity).GetComponent<Building>();
            FollowBuilding();
        }

        private void ClearArea()
        {
            TileBase[] toClear = new TileBase[prevArea.x * prevArea.y * prevArea.z];
            FillTiles(toClear, TileType.Empty);
            tempTilemap.SetTilesBlock(prevArea, toClear);
        }

        private void FollowBuilding()
        {
            ClearArea();
            temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
            BoundsInt buildingArea = temp.area;

            TileBase[] baseArray = GetTilesBlock(buildingArea, mainTilemap);
            int size = baseArray.Length;
            TileBase[] tileArray = new TileBase[size];

            for (int i = 0; i < baseArray.Length; i++)
                if (baseArray[i] == _tileBases[TileType.White])
                {
                    tileArray[i] = _tileBases[TileType.Green];
                }
                else
                {
                    FillTiles(tileArray, TileType.Red);
                    break;
                }
            
            tempTilemap.SetTilesBlock(buildingArea, tileArray);
            prevArea = buildingArea;
        }

        #endregion
    }

    public enum TileType
    {
        Empty,
        White,
        Green,
        Red,
    }
}