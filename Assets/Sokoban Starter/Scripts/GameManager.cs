using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[][] arrayGrids = new GameObject[5][];//5 rows

    // Start is called before the first frame update
    void Start()
    {
        //initialize each row as 10 columns;
        for(int i = 0; i < 5; i++)
        {
            arrayGrids[i] = new GameObject[10];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
