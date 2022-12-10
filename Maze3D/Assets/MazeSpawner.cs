using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject CellPrefab;

    public Vector3 CellSize = new Vector3(1,1,0);

    void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity).GetComponent<Cell>();

                c.WallLeft.SetActive(maze[x, y].WallLeft); //делаем стену активной, если такая стена есть в переданном массиве
                c.WallBottom.SetActive(maze[x, y].WallBottom);
            }
        }
    }

    void Update()
    {
        
    }
}
