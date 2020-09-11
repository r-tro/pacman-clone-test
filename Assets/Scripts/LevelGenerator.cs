using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float TileSize;
    public Vector2 StartPoint;
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
        for (int i = 0; i < 15; i++) // rows
        {
            for (int j = 0; j < 14; j++) // columns
            {
                //Debug.Log("prefab" + prefab + " + tile " +tile);            
                GameObject prefab = Resources.Load("tile_" + levelMap[i, j].ToString()) as GameObject;
                GameObject tile = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                tile.transform.position = new Vector3(StartPoint.x + (TileSize * j), StartPoint.y - (TileSize * i), 0);
                if(i >= 1 && j < 14)
                {
                    if (levelMap[i, j] == 1 && levelMap[i, j + 1] == 2 && levelMap[i - 1, j] == 2) // bottom left corner piece
                    {
                        tile.transform.Rotate(0f, 0f, 90f);
                    }
                }
            }
        }
    }




}