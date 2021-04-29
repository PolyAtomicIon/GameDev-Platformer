using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

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

        public bool stopGeneration = true;

        GameObject getRandomPrefabByKey(string key){
            foreach(RoomCell cell in prefabs){
                if( key == cell.key ){
                    if( cell.prefabs.Count == 0 )
                        return null;
                    // change 0 to random index
                    // int index = Random.Range(0, cell.prefabs.Count);
                    int index = ThreadSafeRandom.ThisThreadsRandom.Next(cell.prefabs.Count);
                    return cell.prefabs[index];
                }
            }

            return null;
        }

        void InstantiatePrefab(int x, int y, string key){

            if( key == "" ){
                // int index = Random.Range(2, prefabs.Count);
                int index = ThreadSafeRandom.ThisThreadsRandom.Next(2, prefabs.Count);
                key = prefabs[index].key;
            }

            GameObject prefab = getRandomPrefabByKey( key );
            if( prefab == null )
                return;

            var prefabGO = Instantiate(prefab, new Vector3(x * cellSizeX, -y * cellSizeY, 0), Quaternion.identity, piece.transform);
            prefabGO.name = $"({x}, {y})";
            gameObjects[y, x] = prefabGO;
        }

        void Update()
        {

            if( !stopGeneration ){
                if( piece == null ){
                	piece = GameObject.Find("Piece");
                    if( piece != null )
                        DestroyImmediate(piece);
                    piece = new GameObject("Piece");
                }
                
                if( gameObjects == null )
                    gameObjects = new GameObject[matrix.GridSize.y, matrix.GridSize.x];

                var cells = matrix.GetCells();

                for (var y = 0; y < matrix.GridSize.y; y++)
                {
                    for (var x = 0; x < matrix.GridSize.x; x++)
                    {
                        if( gameObjects[y, x] == null ){
                            InstantiatePrefab(x, y, cells[y, x]);
                        }
                        else{
                            if(  gameObjects[y, x].name == cells[y, x] )
                                continue;

                            DestroyImmediate(gameObjects[y, x]);                            
                            InstantiatePrefab(x, y, cells[y, x]);
                        }
                    }
                }                
            }

        }

    }
}
