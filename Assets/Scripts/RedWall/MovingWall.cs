using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private int movingSwitch;

    // Update is called once per frame
    void Update()
    {
        if (movingSwitch == 0)
        {
            WallMoveLeft();
        }
        else if (movingSwitch == 1)
        {
            WallMoveRight();
        }
    }

    void WallMoveLeft()
    {
        transform.position += (new Vector3(-1, 0, 0) * Time.deltaTime);
    }

    void WallMoveRight()
    {
        transform.position += (new Vector3(1, 0, 0) * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MoveWallTriggerLeft")
        {
            movingSwitch = 1;
        }

        else if (other.gameObject.name == "MoveWallTriggerRight")
        {
            movingSwitch = 0;
        }
    }
}
