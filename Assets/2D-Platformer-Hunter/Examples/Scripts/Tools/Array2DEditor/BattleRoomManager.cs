using UnityEngine;

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
    
        GameObject piece;
        GameObject[,] gameObjects;

    	// void Start()
        // {
        //     if (matrix == null || prefabToInstantiate == null)
        //     {
        //         Debug.LogError("Fill in all the fields in order to start this example.");
        //         return;
        //     }
    
        //     var cells = matrix.GetCells();
    
        //     piece = new GameObject("Piece");
        //     gameObjects = new GameObject[matrix.GridSize.y, matrix.GridSize.x];

        //     for (var y = 0; y < matrix.GridSize.y; y++)
        //     {
        //         for (var x = 0; x < matrix.GridSize.x; x++)
        //         {
        //             if (cells[y, x] == "a")
        //             {
        //                 var prefabGO = Instantiate(prefabToInstantiate, new Vector3(x * 3, -y, 0), Quaternion.identity, piece.transform);
        //                 prefabGO.name = $"({x}, {y})";
        //                 gameObjects[y, x] = prefabGO;
        //             }
        //         }
        //     }
    	// }

        void InstantiatePrefab(int x, int y){
            var prefabGO = Instantiate(prefabToInstantiate, new Vector3(x * cellSizeX, -y * cellSizeY, 0), Quaternion.identity, piece.transform);
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
                            InstantiatePrefab(x, y);
                    }
                    else{
                        if( cells[y, x] != "" ) {
                            if(  gameObjects[y, x].name == cells[y, x] )
                                continue;

                            DestroyImmediate(gameObjects[y, x]);                            
                            InstantiatePrefab(x, y);
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
