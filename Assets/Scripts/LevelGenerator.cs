using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float TileSize;
    public Vector2 StartPoint;
    /*
    public int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };
    */
    public int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1}
    };

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false); //1920x1080, no fullscreen
        TileSize = 0.33f;
        StartPoint = new Vector2(-4f, 4.5f);
        LevelMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelMap()
    {
        for (int i = 0; i < levelMap.GetLength(0); i++) // rows (y)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++) // columns (x)
            {
                //Debug.Log("prefab" + prefab + " + tile " +tile);            
                GameObject prefab = Resources.Load("tile_" + levelMap[i, j].ToString()) as GameObject;
                GameObject tile = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                tile.transform.position = new Vector3(StartPoint.x + (TileSize * j), StartPoint.y - (TileSize * i), 0);
                tile.transform.localScale = new Vector3(TileSize, TileSize, 1);
                if (i > 0 && j < levelMap.GetLength(1))
                {
                    // OUTSIDE CORNERS
                    if (levelMap[i, j] == 1)
                    {
                        /*if (levelMap[i, j+1] == 2 && levelMap[i-1, j] == 2) // bottom left (OUTSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        */
                        /*
                        if (levelMap[i+1, j] == 2 && j > 0) // top right (OUTSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, -90f);
                        }
                        */
                        if (levelMap[i-1, j] == 2 && j > 0) // bottom right (OUTSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, 180f);
                        }
                    }
                    // OUTSIDE CORNERS
                    // OUTSIDE WALLS
                    if (levelMap[i, j] == 2)
                    {
                        /*
                        if (levelMap[i+1, j] == 2 || levelMap[i-1, j] == 2 ) // vertical outside wall if there is another wall next to it
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        */
                    }
                    // OUTSIDE WALLS
                    // INSIDE CORNERS
                    if (levelMap[i, j] == 3)
                    {
                        if ((levelMap[i, j-1] == 3 || levelMap[i, j-1] == 4) && j > 0) // top right (INSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, -90f);
                        }
                        if ((levelMap[i-1, j] == 3 || levelMap[i-1, j] == 4) && levelMap[i+1, j] != 4) // bottom left (INSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        if ((levelMap[i, j-1] == 3 || levelMap[i, j-1] == 4) && levelMap[i-1, j] != 5) // bottom right (INSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, 180f);
                        }
                    }
                    // INSIDE CORNERS
                    // INSIDE WALLS
                    if (levelMap[i, j] == 4)
                    {
                        if (levelMap[i,j-1] == 4 || levelMap[i, j-1] == 3) // vertical inside wall if there is another wall next to it
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        if (levelMap[i, j - 2] == 5) // vertical inside wall if there is another wall next to it
                        {
                            //tile.transform.Rotate(0f, 0f, 90f);
                        }
                    }
                    // INSIDE WALLS
                }
            }
        }
    }

}