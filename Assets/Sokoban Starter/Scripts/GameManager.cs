using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace block
{
    public class GameManager : MonoBehaviour
    {
        public static void Attempt(Vector2Int movement, GameObject obj)
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
                    print("empty move");
                    GameManager.Move(movement, obj);
                }
                else
                {
                    Attempt(movement, FindAttemptingBlock(movement, obj));
                    if (FindAttemptingBlock(movement, obj) == null)
                    {
                        print("blocking move");
                        Move(movement, obj);
                    }
                }
            }
        }

        public static void Move(Vector2Int movement, GameObject obj)
        {
            obj.GetComponent<GridObject>().gridPosition += movement;
            print("move method");
        }

        public static GameObject FindAttemptingBlock(Vector2 movement, GameObject obj)
        {
            GameObject[] blockObjects = GameObject.FindGameObjectsWithTag("block");
            foreach (GameObject blockObject in blockObjects)
            {
                if ( obj.GetComponent<GridObject>().gridPosition + movement == blockObject.GetComponent<GridObject>().gridPosition)
                {
                    return blockObject;
                }
            }
            return null;
        }
    }
}
