using Assets.SRC.ProceduralMapGeneration.Mono.Behaviors;
using Assets.SRC.ProceduralMapGeneration.Structs;
using Assets.SRC.ProceduralMapGeneration.Utilities;
using Assets.SRC.ProceduralMapGeneration.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.SRC.ProceduralMapGeneration.Mono.Managers
{
    internal class DungeonManager : MonoBehaviour
    {
        public GameObject TempPrefab;
        public Transform GridParent;
        public int GridSize;
        public float GridScale;
        [Range(0,100)]
        public float Threshold;
        public DirectionalTilesScriptableObject scriptRef;

        private List<GameObject> gridRelations = new List<GameObject>();

        private readonly PopulateTilePositions _populateTilePositionsBehavior = new PopulateTilePositions();
        private readonly GridCreate _gridCreate = new GridCreate();
        private void Start()
        {
            SetUpGrid();
        }
        private void SetUpGrid()
        {
            gridRelations.Clear();
            Vector3[] grid = _gridCreate.SquareGrid2DHorizontal(GridSize, GridScale);//
            Vector3[] mapGrid = _gridCreate.CreatePath(grid, GridScale,GridSize, Threshold);// this needs editing
            /// need to create map from this 
             gridRelations = _gridCreate.PlaceGameObjectsAtGridPositions(mapGrid, GridParent);//
            gridRelations = _gridCreate.FindChunkNeigbors(GridScale, gridRelations);
             //gridRelations = _gridCreate.CreateMapPatern(gridRelations);
           // gridRelations = _gridCreate.CleanMap(GridSize, gridRelations);
            gridRelations = _gridCreate.FindChunkNeigbors(GridScale, gridRelations);
            // gridRelations = _gridCreate.AssignDirectionIDAccordingToPresentNeighbors(listedObjects);
            gridRelations = _gridCreate.AssignChunkTypes(gridRelations);

            _populateTilePositionsBehavior.SetChildTile(scriptRef, gridRelations);
        }

    }
}
