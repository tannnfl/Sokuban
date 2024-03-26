using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Control")]
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Up))
        {

        }
        else if (Input.GetKeyDown(Down))
        {

        }
        else if (Input.GetKeyDown(Left))
        {

        }
        else if (Input.GetKeyDown(Right))
        {

        }
    }
}
