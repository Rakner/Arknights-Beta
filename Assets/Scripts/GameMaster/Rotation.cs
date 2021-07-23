using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public static int positionToRotate;
    // Start is called before the first frame update
    void Start()
    {
        positionToRotate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            positionToRotate = -90;
            Debug.Log(positionToRotate);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            positionToRotate = 90;
            Debug.Log(positionToRotate);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            positionToRotate = 180;
            Debug.Log(positionToRotate);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            positionToRotate = 0;
            Debug.Log(positionToRotate);
        }
    }
}
