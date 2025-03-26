using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public int width = 4;
    public int height = 4;
    private List<Cell> cells = new List<Cell>();
    public GameObject cellPrefab; 

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cells.Add(new Cell(new Vector2Int(x, y), 0));
            }
        }
        CreateCell();
        CreateCell();
    }

    public Vector2Int GetEmptyPosition()
    {
        List<Vector2Int> emptyPositions = new List<Vector2Int>();

        foreach (var cell in cells)
        {
            if (cell.Value == 0)
                emptyPositions.Add(cell.Position);
        }

        if (emptyPositions.Count > 0)
        {
            return emptyPositions[Random.Range(0, emptyPositions.Count)];
        }

        return new Vector2Int(-1, -1);
    }

    public void CreateCell()
    {
        Vector2Int position = GetEmptyPosition();
        if (position.x == -1) 
        { 
            return; 
        }

        int value;
        int prob = Random.Range(0, 10);
        if (prob <= 9)
        {
            value = 1;
        }
        else
        {
            value = 2;
        }
        Cell newCell = new Cell(position, value);
        cells.Add(newCell);

        GameObject cellViewObject = Instantiate(cellPrefab);
        CellView cellView = cellViewObject.GetComponent<CellView>();
        cellView.Init(newCell);
    }
}
