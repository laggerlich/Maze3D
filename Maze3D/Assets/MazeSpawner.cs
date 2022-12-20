using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab;
    public Vector3 CellSize = new Vector3(1,1,0);
    public ExitRenderer ExitRenderer;
    public GameObject healPill;
    public GameObject pathPill;
    public GameObject trapPill;
    public GameObject endPill;
    public int healsCount = 25;
    public int pathsCount = 5;
    public int trapCount = 2;
    private int endCount = 1;

    public Maze maze; 

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity).GetComponent<Cell>();

                c.WallLeft.SetActive(maze.cells[x, y].WallLeft); //делаем стену активной, если такая стена есть в переданном массиве
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
            }
        }
        InstantiateHeal();
        InstantiatePath();
        InstantiateTrap();
        InstantiateEnd();
        ExitRenderer.DrawExit();
    }

    private void InstantiateHeal()
    {
        for(int i = 0; i < healsCount; i++)
        {
            Vector2Int position = maze.pills[i];
            GameObject pill = Instantiate(healPill, new Vector3((position.x + 0.5f)*CellSize.x, 0.3f* CellSize.x, (position.y + 0.5f)*CellSize.x), Quaternion.identity);

        }
    }

    private void InstantiatePath()
    {
        for (int i = healsCount; i < healsCount+pathsCount; i++)
        {
            Vector2Int position = maze.pills[i];
            GameObject pill = Instantiate(pathPill, new Vector3((position.x + 0.5f) * CellSize.x, 0.3f * CellSize.x, (position.y + 0.5f) * CellSize.x), Quaternion.identity);

        }
    }

    private void InstantiateTrap()
    {
        for (int i = healsCount + pathsCount; i < healsCount + pathsCount + trapCount; i++)
        {
            Vector2Int position = maze.pills[i];
            GameObject pill = Instantiate(trapPill, new Vector3((position.x + 0.5f) * CellSize.x, 0.3f * CellSize.x, (position.y + 0.5f) * CellSize.x), Quaternion.identity);

        }
    }
    private void InstantiateEnd()
    {
        for (int i = healsCount + pathsCount + trapCount; i < healsCount + pathsCount + trapCount + 1; i++)
        {
            Vector2Int position = maze.pills[i];
            GameObject pill = Instantiate(endPill, new Vector3((position.x + 0.5f) * CellSize.x, 0.3f * CellSize.x, (position.y + 0.5f) * CellSize.x), Quaternion.identity);

        }
    }
}
