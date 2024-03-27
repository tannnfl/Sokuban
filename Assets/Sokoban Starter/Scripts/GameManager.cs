using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace block
{
    public class GameManager : MonoBehaviour
    {
        public static void Attempt(Vector2Int movement, GameObject obj)
        {
            if (obj.tag == "player" || obj.tag == "smooth" || obj.tag == "sticky")
            {
                //grid position of attempting grid
                int _x = (obj.GetComponent<GridObject>().gridPosition + movement).x;
                int _y = (obj.GetComponent<GridObject>().gridPosition + movement).y;
                //check not out of boundary
                if (0 < _x && _x <= 10 &&
                    0 < _y && _y <= 5)
                {
                    //check if next grid is empty
                    if (FindAttemptingBlock(movement, obj) == null)
                    {
                        Move(movement, obj);
                        Pull(movement, obj);
                    }
                    else
                    {
                        Attempt(movement, FindAttemptingBlock(movement, obj));
                        if (FindAttemptingBlock(movement, obj) == null)
                        {
                            Move(movement, obj);
                            Pull(movement, obj);
                        }
                    }
                }
            }
        }

        //clingy box
        public static void Pull(Vector2Int movement, GameObject obj)
        {

            //clingy 
            if (FindAttemptingBlock(-movement * 2, obj) != null //check if pulled grid has block
                && (FindAttemptingBlock(-movement * 2, obj).tag == "clingy" || FindAttemptingBlock(-movement * 2, obj).tag == "sticky")) //check if attempting to move obj moved
            {
                GameObject _obj = FindAttemptingBlock(-movement * 2, obj);
                //grid position of attempting grid
                int _x = (_obj.GetComponent<GridObject>().gridPosition + movement).x;
                int _y = (_obj.GetComponent<GridObject>().gridPosition + movement).y;
                //check not out of boundary
                if (0 < _x && _x <= 10 &&
                    0 < _y && _y <= 5)
                {
                    //check if next grid is empty
                    if (FindAttemptingBlock(movement, _obj) == null)
                    {
                        _obj.GetComponent<GridObject>().gridPosition += movement;
                        Pull(movement, _obj);
                    }
                    else
                    {
                        Attempt(movement, FindAttemptingBlock(movement, _obj));
                        if (FindAttemptingBlock(movement, _obj) == null)
                        {
                            _obj.GetComponent<GridObject>().gridPosition += movement;
                            Pull(movement, _obj);
                        }
                    }
                }
                //Attempt(movement, FindAttemptingBlock(-movement * 2, obj));
            }

            
            //sticky left & right
            Vector2Int direction = new Vector2Int (movement.y,movement.x);
            if (FindAttemptingBlock(direction - movement,obj) != null
                && FindAttemptingBlock(direction - movement, obj).tag == "sticky")
            {
                GameObject _obj = FindAttemptingBlock(direction - movement, obj);
                //grid position of attempting grid
                int _x = (_obj.GetComponent<GridObject>().gridPosition + movement).x;
                int _y = (_obj.GetComponent<GridObject>().gridPosition + movement).y;
                //check not out of boundary
                if (0 < _x && _x <= 10 &&
                    0 < _y && _y <= 5)
                {
                    //check if next grid is empty
                    if (FindAttemptingBlock(movement, _obj) == null)
                    {
                        _obj.GetComponent<GridObject>().gridPosition += movement;
                        Pull(movement, _obj);
                    }
                    else
                    {
                        Attempt(movement, FindAttemptingBlock(movement, _obj));
                        if (FindAttemptingBlock(movement, _obj) == null)
                        {
                            _obj.GetComponent<GridObject>().gridPosition += movement;
                            Pull(movement, _obj);
                        }
                    }
                }
                //Attempt(movement, FindAttemptingBlock(movement, obj));
            }
            if (FindAttemptingBlock(-direction - movement, obj) != null
                && FindAttemptingBlock(-direction - movement, obj).tag == "sticky")
            {
                GameObject _obj = FindAttemptingBlock(-direction - movement, obj);
                //grid position of attempting grid
                int _x = (_obj.GetComponent<GridObject>().gridPosition + movement).x;
                int _y = (_obj.GetComponent<GridObject>().gridPosition + movement).y;
                //check not out of boundary
                if (0 < _x && _x <= 10 &&
                    0 < _y && _y <= 5)
                {
                    //check if next grid is empty
                    if (FindAttemptingBlock(movement, _obj) == null)
                    {
                        _obj.GetComponent<GridObject>().gridPosition += movement;
                        Pull(movement, _obj);
                    }
                    else
                    {
                        Attempt(movement, FindAttemptingBlock(movement, _obj));
                        if (FindAttemptingBlock(movement, _obj) == null)
                        {
                            _obj.GetComponent<GridObject>().gridPosition += movement;
                            Pull(movement, _obj);
                        }
                    }
                }
                //Attempt(movement, FindAttemptingBlock(-movement, obj));
            }
            
        }

        public static void Move(Vector2Int movement, GameObject obj)
        {
            switch (obj.tag)
            {
                case "player":
                    //keyboard command to move; push other
                    obj.GetComponent<GridObject>().gridPosition += movement;
                    print("player move");
                    break;
                case "smooth":
                    //can be pushed to move; push other
                    obj.GetComponent<GridObject>().gridPosition += movement;
                    print("smooth move");
                    break;
                case "wall":
                    //cannot be pushed to move or push other
                    print("wall stay");
                    break;
                case "clingy":
                    //inverse of smooth, can only be pulled; can't be pushed
                    print("clingy stay");
                    break;
                case "sticky":
                    //stick to moving block; if attempting grid is blocked, stop
                    obj.GetComponent<GridObject>().gridPosition += movement;
                    break;
            }
        }

        public static GameObject FindAttemptingBlock(Vector2Int movement, GameObject obj)
        {
            GridObject[] blockObjects = GameObject.FindObjectsOfType<GridObject>();
            foreach(GridObject blockObject in blockObjects)
            {
                if ( obj.GetComponent<GridObject>().gridPosition + movement == blockObject.gridPosition)
                {
                    return blockObject.gameObject;
                }
            }
            return null;
        }
    }
}
