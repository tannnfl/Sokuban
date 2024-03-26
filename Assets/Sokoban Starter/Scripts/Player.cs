using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [Header("Player Control")]
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    public UnityVector2Event MoveUp;
    public UnityVector2Event MoveDown;
    public UnityVector2Event MoveLeft;
    public UnityVector2Event MoveRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Up))
        {
            MoveUp.Invoke(GetComponent<GridObject>().gridPosition);
        }
        else if (Input.GetKeyDown(Down))
        {
            MoveDown.Invoke(GetComponent<GridObject>().gridPosition);
        }
        else if (Input.GetKeyDown(Left))
        {
            MoveLeft.Invoke(GetComponent<GridObject>().gridPosition);
        }
        else if (Input.GetKeyDown(Right))
        {
            MoveRight.Invoke(GetComponent<GridObject>().gridPosition);
        }

     }    
}

    [System.Serializable]
    public class UnityVector2Event : UnityEvent<Vector2>
{

}
