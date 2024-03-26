using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridReporter : MonoBehaviour
{
    GameManager gm;
    Vector2Int gridPosition;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Grid").GetComponent<GameManager>();
        gridPosition = GetComponent<GridObject>().gridPosition;
    }

    // Update is called once per frame
    void Update()
    {
        gm.arrayGrids[gridPosition.x][gridPosition.y] = this.gameObject;
    }
}
