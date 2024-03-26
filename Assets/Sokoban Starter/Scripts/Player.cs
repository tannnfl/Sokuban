using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace block
{
    public class Player : MonoBehaviour
    {
        GameManager gm;
        Vector2Int gridPosition;

        [Header("Player Control")]
        public KeyCode upKey = KeyCode.W;
        public KeyCode downKey = KeyCode.S;
        public KeyCode leftKey = KeyCode.A;
        public KeyCode rightKey = KeyCode.D;

        void Start()
        {
            gridPosition = GetComponent<GridObject>().gridPosition;
            gm = GameObject.Find("Grid").GetComponent<GameManager>();
        }
        void Update()
        {
            KeyboardCommand();
        }

        void KeyboardCommand()
        {
            if (Input.GetKeyDown(upKey))
            {
                GameManager.Attempt(new Vector2Int(0, -1), gameObject);
            }
            else if (Input.GetKeyDown(downKey))
            {
                GameManager.Attempt(new Vector2Int(0, 1), gameObject);
            }
            else if (Input.GetKeyDown(leftKey))
            {
                GameManager.Attempt(new Vector2Int(-1, 0), gameObject);
            }
            else if (Input.GetKeyDown(rightKey))
            {
                GameManager.Attempt(new Vector2Int(1, 0), gameObject);
            }
        }
    }
}