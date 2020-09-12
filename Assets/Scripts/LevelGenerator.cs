using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float TileSize;
    public Vector2 StartPoint;
    public int[,] levelMap =
    {
       //           j
       //0,1,2,3,4,5,6,7,8,9,10,11,12   
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},//0
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},//1
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},//2
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},//3
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},//4
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},//5
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},//6
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},//7
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},//8  i
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},//9  9,8 == 3
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},//10  10,8 == 3
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},//11  11,8 == 4
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},//12  12,8 == 4
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},//13
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},//14
    };

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false); //1920x1080, no fullscreen
        TileSize = 1;
        StartPoint = new Vector2(1, 1);
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
                //Debug.Log("prefab" + prefab + " + tile " +tile);\
                Transform TopLeft = GameObject.Find("TopLeft").transform;
                GameObject prefab = Resources.Load("tile_" + levelMap[i, j].ToString()) as GameObject;
                GameObject tile = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                tile.transform.position = new Vector3(StartPoint.x + (TileSize * j), StartPoint.y - (TileSize * i), 0);
                tile.gameObject.tag = "Tile" + (levelMap[i, j].ToString());
                tile.transform.parent = TopLeft;

                ////////
                ///

                /*
                Transform TopRight = GameObject.Find("TopRight").transform;
                GameObject tile2 = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                tile2.gameObject.tag = "Tile" + (levelMap[i, j].ToString());
                tile2.transform.parent = TopRight;
                tile2.transform.position = new Vector3((StartPoint.x + 27) - (TileSize * j), (StartPoint.y) - (TileSize * i), 0);
                TopRight.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                */

                ////////
                if (i > 0 && j < levelMap.GetLength(1))
                {
                    // OUTSIDE CORNERS
                    if (levelMap[i, j] == 1)
                    {
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i, j + 1] == 2 || levelMap[1, j - 1] == 2)) // bottom left (OUTSIDE) corner piece 
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i+1, j] == 2 && j > 0)) // top right (OUTSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, -90f);
                        }
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i-1, j] == 2 && j > 0)) // bottom right (OUTSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, 180f);
                        }
                        else
                        { 
                            Debug.Log("out of bounds" + levelMap[i, j]); 
                        }
                    }
                    // OUTSIDE CORNERS
                    // OUTSIDE WALLS
                    if (levelMap[i, j] == 2)
                    {
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i+1, j] == 2 || levelMap[i-1, j] == 2 )) // vertical outside wall if there is another wall next to it
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        else
                        {
                            Debug.Log("out of bounds" + levelMap[i, j]);
                        }
                    }
                    // OUTSIDE WALLS
                    // INSIDE CORNERS
                    if (levelMap[i, j] == 3)
                    {
                        if (j + 1 <= levelMap.GetLength(1) && ((levelMap[i, j-1] == 3 || levelMap[i, j-1] == 4) && j > 0)) // top right (INSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, -90f);
                        }
                        if (j + 1 <= levelMap.GetLength(1) && ((levelMap[i-1, j] == 3 || levelMap[i-1, j] == 4) && levelMap[i+1, j] != 4)) // bottom left (INSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        if (j + 1 <= levelMap.GetLength(1) && ((levelMap[i, j-1] == 3 || levelMap[i, j-1] == 4) && levelMap[i-1, j] != 5)) // bottom right (INSIDE) corner piece
                        {
                            tile.transform.Rotate(0f, 0f, 180f);
                        }
                        else
                        {
                            Debug.Log("out of bounds" + levelMap[i, j]);
                        }

                    }
                    // INSIDE CORNERS
                    // INSIDE WALLS
                    if (levelMap[i, j] == 4)
                    {
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i,j-1] == 4 || levelMap[i, j-1] == 3)) // vertical inside wall if there is another wall next to it
                        {
                            tile.transform.Rotate(0f, 0f, 90f);
                        }
                        if ((levelMap[i, j] == 4 && ((i == 8 || i == 7 || i == 11 || i == 12) && j == 8))) 
                        {
                            tile.transform.Rotate(0f, 0f, -90f);
                        }
                        else
                        {
                            Debug.Log("out of bounds" + levelMap[i, j]);
                        }
                    }
                    // INSIDE WALLS
                }
                LevelMapTopRight();
            }

        }
    }

    public void LevelMapTopRight()
    {
        //Transform TopRight = GameObject.Find("TopLeft").transform;
        //Transform duplicate = Instantiate(TopRight);
        //duplicate.transform.parent = TopRight;
        //Debug.Log("so far theres " + TopRight);
        //duplicate.gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }
}