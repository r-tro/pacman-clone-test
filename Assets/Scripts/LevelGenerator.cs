using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float TileSize;
    public Vector2 StartPoint;
    public int[,] levelMap =
    {
        /*
         * 0 – Empty (do not instantiate anything)
         * 1 - Outside corner (double lined corener piece in orginal game)
         * 2 - Outside wall (double line in original game)
         * 3 - Inside corner (single lined corener piece in orginal game)
         * 4 - Inside wall (single line in orginal game)
         * 5 - Standard pellet (see Visual Assets above)
         * 6 - Power pellet (see Visual Assets above)
         * 7 - A t junction piece for connecting with adjoining regions 
         */
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},//0
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},//1
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},//2
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},//3
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},//4
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},//5
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},//6
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},//7  i
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},//8
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},//9
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},//10
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},//11
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},//12
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},//13
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},//14
       //0,1,2,3,4,5,6,7,8,9,10,11,12,13
       //             j
    };

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false); //1920x1080, no fullscreen
        TileSize = 1f; //change to sprite 1:1 scale
        StartPoint = new Vector2(1f, 1f);
        LevelMap();
        //Transform Pacman = GameObject.Find("Pacman").transform;
        //Pacman.transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelMap()
    {
        for (int i = 0; i < levelMap.GetLength(0); i++) // column (y)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++) // row (x)
            {
                Transform TopLeft = GameObject.Find("TopLeft").transform;
                GameObject prefab = Resources.Load("tile_" + levelMap[i, j].ToString()) as GameObject;
                GameObject tileTopLeft = Instantiate(prefab) as GameObject;
                tileTopLeft.transform.position = new Vector3(StartPoint.x + (TileSize * j), StartPoint.y - (TileSize * i), 0);
                tileTopLeft.gameObject.tag = "Tile" + (levelMap[i, j].ToString());
                tileTopLeft.transform.SetParent(TopLeft);

                Transform TopRight = GameObject.Find("TopRight").transform;
                GameObject tileTopRight = Instantiate(prefab) as GameObject;
                tileTopRight.transform.position = new Vector3((StartPoint.x + (((levelMap.GetLength(1) * 2) - 1) * TileSize)) - (TileSize * j), StartPoint.y - (TileSize * i), 0);
                tileTopRight.gameObject.tag = "Tile" + (levelMap[i, j].ToString());
                tileTopRight.transform.SetParent(TopRight);

                Transform BottomRight = GameObject.Find("BottomRight").transform;
                GameObject tileBottomRight = Instantiate(prefab) as GameObject;
                tileBottomRight.transform.position = new Vector3(StartPoint.x + (((levelMap.GetLength(1) * 2) - 1) * TileSize) - (TileSize * j), StartPoint.y - (((levelMap.GetLength(0) * 2) - 2) * TileSize) + (TileSize * i), 0);
                tileBottomRight.gameObject.tag = "Tile" + (levelMap[i, j].ToString());
                tileBottomRight.transform.SetParent(BottomRight);

                Transform BottomLeft = GameObject.Find("BottomLeft").transform;
                GameObject tileBottomLeft = Instantiate(prefab) as GameObject;
                tileBottomLeft.transform.position = new Vector3(StartPoint.x + (TileSize * j), StartPoint.y - (((levelMap.GetLength(0) * 2) - 2) * TileSize) + (TileSize * i), 0);
                tileBottomLeft.gameObject.tag = "Tile" + (levelMap[i, j].ToString());
                tileBottomLeft.transform.SetParent(BottomLeft);

                if (levelMap[i, j] == 0) // destroy object if 0 (empty)
                {
                    Destroy(tileTopLeft);
                    Destroy(tileTopRight);
                    Destroy(tileBottomLeft);
                    Destroy(tileBottomRight);
                }
                if (i == 14) // destroy bottom row if flipped vertically
                {
                    Destroy(tileBottomLeft);
                    Destroy(tileBottomRight);
                }
                if (i > 0 && j < levelMap.GetLength(1)) // automatically check piece rotation if next to certain pieces (referencing top left chunk)
                {
                    if (levelMap[i, j] == 1) // OUTSIDE CORNERS
                    {
                        if (j + 1 <= levelMap.GetLength(1) && levelMap[i, j] == 1) // Top Right (OUTSIDE) Corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 0f);
                            tileTopRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomRight.transform.Rotate(0f, 0f, 0f);
                            tileBottomLeft.transform.Rotate(0f, 0f, 270f); //
                        }
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i, j + 1] == 2 || levelMap[1, j - 1] == 2)) // Bottom Left (OUTSIDE) Corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 90f);
                            tileTopRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomRight.transform.Rotate(0f, 0f, 270f);
                            tileBottomLeft.transform.Rotate(0f, 0f, 90f); //
                        }
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i + 1, j] == 2 && j > 0)) // Top Right (OUTSIDE) Corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, -90f);
                            tileTopRight.transform.Rotate(0f, 0f, -90f);
                            tileBottomRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomLeft.transform.Rotate(0f, 0f, -90f); //
                        }
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i - 1, j] == 2 && j > 0)) // Bottom Right (OUTSIDE) Corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 180f);
                            tileTopRight.transform.Rotate(0f, 0f, 0f);
                            tileBottomRight.transform.Rotate(0f, 0f, 0f);
                            tileBottomLeft.transform.Rotate(0f, 0f, 0f); //
                        }
                    }
                    if (levelMap[i, j] == 2) // OUTSIDE WALLS
                    {
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i + 1, j] == 2 || levelMap[i - 1, j] == 2)) // Vertical Wall
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 90f);
                            tileTopRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomLeft.transform.Rotate(0f, 0f, 90f); //
                        }
                    }
                    if (levelMap[i, j] == 3) // INSIDE CORNERS
                    {
                        if (j + 1 <= levelMap.GetLength(1) && levelMap[i, j] == 3) // Top Left (INSIDE) Corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 0f); 
                            tileTopRight.transform.Rotate(0f, 0f, -90f);
                            tileBottomRight.transform.Rotate(0f, 0f, -180f);
                            tileBottomLeft.transform.Rotate(0f, 0f, -270f);
                        }
                        if (j + 1 <= levelMap.GetLength(1) && ((levelMap[i, j - 1] == 3 || levelMap[i, j - 1] == 4) && j > 0)) // Top Right (INSIDE) Corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, -90f); 
                            tileTopRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomRight.transform.Rotate(0f, 0f, 270f);
                            tileBottomLeft.transform.Rotate(0f, 0f, -270f);
                        }
                        if (j + 1 <= levelMap.GetLength(1) && ((levelMap[i - 1, j] == 3 || levelMap[i - 1, j] == 4) && levelMap[i + 1, j] != 4)) // Bottom Left (INSIDE) corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 90f);
                            tileTopRight.transform.Rotate(0f, 0f, -90f);
                            tileBottomRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomLeft.transform.Rotate(0f, 0f, -90f);
                        }
                        if (j + 1 <= levelMap.GetLength(1) && ((levelMap[i, j - 1] == 3 || levelMap[i, j - 1] == 4) && levelMap[i - 1, j] != 5)) // Bottom Right (INSIDE) corner
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 180f);
                            tileTopRight.transform.Rotate(0f, 0f, -180f);
                            tileBottomRight.transform.Rotate(0f, 0f, 180f);
                            tileBottomLeft.transform.Rotate(0f, 0f, -180f);
                        }
                        if (levelMap[i, j] == 3 && (i == 10 && j == 8) || (i == 9 && j == 8)) // Inside Corner (out of bounds manual adjustment)
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, -90f);
                            tileTopRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomRight.transform.Rotate(0f, 0f, -90f);
                            tileBottomLeft.transform.Rotate(0f, 0f, 90f);
                        }
                        if (levelMap[i, j] == 3 && (i == 7 && j == 13)) // Inside Corner (out of bounds manual adjustment)
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, -180f);
                            tileTopRight.transform.Rotate(0f, 0f, -180f);
                            tileBottomRight.transform.Rotate(0f, 0f, -180f);
                            tileBottomLeft.transform.Rotate(0f, 0f, 180f);
                        }
                    }
                    if (levelMap[i, j] == 4) // INSIDE WALLS
                    {
                        if (j + 1 <= levelMap.GetLength(1) && (levelMap[i, j - 1] == 4 || levelMap[i, j - 1] == 3)) // Vertical Inside Wall
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, 90f);
                            tileTopRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomRight.transform.Rotate(0f, 0f, 90f);
                            tileBottomLeft.transform.Rotate(0f, 0f, 90f); 
                        }
                        if (levelMap[i, j] == 4 && (i == 8 || i == 7 || i == 11 || i == 12) && j == 8) // Vertical Inside Wall (out of bounds manual adjustment)
                        {
                            tileTopLeft.transform.Rotate(0f, 0f, -90f);
                            tileTopRight.transform.Rotate(0f, 0f, -90f);
                            tileBottomRight.transform.Rotate(0f, 0f, -90f);
                            tileBottomLeft.transform.Rotate(0f, 0f, -90f); 
                        }
                    }
                }
                else
                {
                    if (levelMap[i, j] == 1 && (i == 0 && j == 0)) // levelMap[0,0]; or starting piece
                    {
                        //Debug.Log("topr right " + tileTopRight + "levelMap[" + i + "," + j + "]");
                        tileTopLeft.transform.Rotate(0f, 0f, 0f);
                        tileTopRight.transform.Rotate(0f, 0f, -90f); 
                        tileBottomRight.transform.Rotate(0f, 0f, -180f);
                        tileBottomLeft.transform.Rotate(0f, 0f, 90f);
                    }
                    if (levelMap[i, j] == 7) // levelMap[0,13]; or t-junction piece
                    {
                        tileBottomLeft.transform.Rotate(0f, 0f, 180f);
                        tileBottomRight.transform.Rotate(0f, 0f, 180f);
                    }
                }
            }
        }
    }
}