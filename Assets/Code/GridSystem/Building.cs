using System;
using UnityEngine;

namespace Code.GridSystem
{
    public class Building : MonoBehaviour
    {
        public bool Placed { get; private set; }
        public BoundsInt area;
        
        private void Start()
        {
            throw new NotImplementedException();
        }

        #region BuildMethods

        public bool CanBePlaced()
        {
            Vector3Int positionInt = GridBuildSystem.current.gridLayout.LocalToCell(transform.position);
            BoundsInt areaTemp = area;
            areaTemp.position = positionInt;

            return GridBuildSystem.current.CanTakeArea(areaTemp);
        }

        public void Place()
        {
            Vector3Int positionInt = GridBuildSystem.current.gridLayout.LocalToCell(transform.position);
            BoundsInt areaTemp = area;
            areaTemp.position = positionInt;
            Placed = true;
            GridBuildSystem.current.TakeArea(areaTemp);
        }
        #endregion
    }
}