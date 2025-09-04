using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] Vector2Int size;
    [SerializeField] CellManager cellPrefab;
    // Start is called before the first frame update
    void Awake()
    {

        StartCoroutine(WallGenerator(size));
   
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private IEnumerator WallGenerator(Vector2Int size)
    {
        //creates a grid and adds the cells in a list
        List<CellManager> cellList = new List<CellManager>();

        for (int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                Vector2 spawnpos = new Vector2(i -(size.x/2f),j -(size.y/2f));
                CellManager newCell = Instantiate(cellPrefab,spawnpos,Quaternion.identity);
                cellList.Add(newCell);
                yield return null;
               
            }
        }
        
        List<CellManager> currentPath = new List<CellManager>();
        List<CellManager> completedCells = new List<CellManager>();
        // selects a starting point
        currentPath.Add(cellList[Random.Range(0,cellList.Count)]);
        currentPath[0].SetCellState(cellState.current);

        while(completedCells.Count < cellList.Count) { 
            List<int> possibleNextCell = new List<int>();
            List<int> possibleDirection = new List<int>();

            int currentCellIndex = cellList.IndexOf(currentPath[currentPath.Count -1]);
            int currentCellX = currentCellIndex / size.y;
            int currentCellY = currentCellIndex % size.y;

            if(currentCellX < size.x + 1)
            {
                if (!completedCells.Contains(cellList[currentCellIndex + size.y]) && !currentPath.Contains(cellList[currentCellIndex + size.y]))
                {
                    possibleDirection.Add(1);
                    possibleNextCell.Add(currentCellIndex+size.y);
                }
                
            }

            if(currentCellX > 0)
            {
                if (!completedCells.Contains(cellList[currentCellIndex - size.y]) && !currentPath.Contains(cellList[currentCellIndex - size.y]))
                {
                    possibleDirection.Add(2);
                    possibleNextCell.Add(currentCellIndex-size.y);
                }
            }

            if(currentCellY < size.y -1)
            {
                if (!completedCells.Contains(cellList[currentCellIndex+1]) && !currentPath.Contains(cellList[currentCellIndex +1]))
                {
                    possibleDirection.Add(3);
                    possibleNextCell.Add(currentCellIndex + 1);
                }
            }

            if (currentCellY > 0)
            {
                if (!completedCells.Contains(cellList[currentCellIndex-1]) && !currentPath.Contains(cellList[currentCellIndex - 1]))
                {
                    possibleDirection.Add(4);
                    possibleNextCell.Add(currentCellIndex - 1);
                }
            }

            if(possibleDirection.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirection.Count);
                CellManager chosenCell = cellList[possibleDirection[chosenDirection]];

                currentPath.Add(chosenCell);
                chosenCell.SetCellState(cellState.current);
            }

            yield return null;
        }
    }


}
