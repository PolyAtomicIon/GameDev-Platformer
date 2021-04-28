using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Array2DEditor
{
    
    [ExecuteInEditMode]
    public class BattleRoomManager : MonoBehaviour
    {

        public int cellSizeX;
        public int cellSizeY;

        [SerializeField]
        private Array2DString matrix;

        [SerializeField]
        private GameObject prefabToInstantiate = null;
        
        [System.Serializable]
        public class RoomCell
        {
            public string key;
            public List<GameObject> prefabs;
        }

        [SerializeField]
        private List<RoomCell> prefabs;

        GameObject piece;
        GameObject[,] gameObjects;

        GameObject getRandomPrefabByKey(string key){
            foreach(RoomCell cell in prefabs){
                if( key == cell.key ){
                    if( cell.prefabs.Count == 0 )
                        return null;
                    // change 0 to random index
                    int index = 0;
                    return cell.prefabs[index];
                }
            }

            return null;
        }

        void InstantiatePrefab(int x, int y, string key){
            GameObject prefab = getRandomPrefabByKey( key );
            if( prefab == null )
                return;

            var prefabGO = Instantiate(prefab, new Vector3(x * cellSizeX, -y * cellSizeY, 0), Quaternion.identity, piece.transform);
            prefabGO.name = $"({x}, {y})";
            gameObjects[y, x] = prefabGO;
        }

        void Update()
        {
            if( piece == null )
                piece = new GameObject("Piece");
            
            if( gameObjects == null )
                gameObjects = new GameObject[matrix.GridSize.y, matrix.GridSize.x];

            var cells = matrix.GetCells();

            for (var y = 0; y < matrix.GridSize.y; y++)
            {
                for (var x = 0; x < matrix.GridSize.x; x++)
                {
                    if( gameObjects[y, x] == null ){
                        if( cells[y, x] != "" )
                            InstantiatePrefab(x, y, cells[y, x]);
                    }
                    else{
                        if( cells[y, x] != "" ) {
                            if(  gameObjects[y, x].name == cells[y, x] )
                                continue;

                            DestroyImmediate(gameObjects[y, x]);                            
                            InstantiatePrefab(x, y, cells[y, x]);
                        }
                        else{
                            DestroyImmediate(gameObjects[y, x]);
                            gameObjects[y, x] = null;
                        }
                    }
                }
            }
        }

    }
}
