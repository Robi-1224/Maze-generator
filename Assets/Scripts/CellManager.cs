using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum cellState
{
    available,
    selected,
    current
}
public class CellManager : MonoBehaviour
{
    [SerializeField] GameObject[] cells;
    [SerializeField] SpriteRenderer floorRenderer;

    
    public void SetCellState(cellState state)
    {
        switch(state)
        {
            case cellState.available: floorRenderer.color = Color.white; 
                 break;
            case cellState.selected: floorRenderer.color = Color.red; 
                break;
            case cellState.current: floorRenderer.color = Color.green;
                break;
        }
    }
}
 