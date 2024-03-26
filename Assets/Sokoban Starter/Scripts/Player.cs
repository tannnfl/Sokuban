using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    GameManager gm;
    Vector2Int gridPosition;

    [Header("Player Control")]
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        gridPosition = GetComponent<GridObject>().gridPosition;
        gm = GameObject.Find("Grid").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardCommand();
    }

    void KeyboardCommand()
    {
        if (Input.GetKeyDown(upKey))
        {
            
        }
        else if (Input.GetKeyDown(downKey))
        {

        }
        else if (Input.GetKeyDown(leftKey))
        {

        }
        else if (Input.GetKeyDown(rightKey))
        {

        }
    }

    public void Attempt(Vector2Int movement)
    {
        //grid position of attempting grid
        int _x = (gridPosition + movement).x;
        int _y = (gridPosition + movement).y;
        //check not out of boundary
        if (0 < _x && _x < 10 &&
            0 < _y && _y < 5)
        {
            //check if next grid is empty
            if (gm.arrayGrids[_x][_y] == null)
            {
                Move(movement);
            }
            else
            {
                gm.arrayGrids[_x][_y].Attempt(movement);
            }
        }
        //check if right empty
        //if empty, move
        //if not,
        //  right.moveright()
        //  check if empty, move
    }
    void Move(Vector2Int movement)
    {
        gridPosition += movement;
    }
}