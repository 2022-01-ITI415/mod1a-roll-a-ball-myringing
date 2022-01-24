using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWall : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject door;
    public GameObject tigger;
    public GameObject message;

    // Update is called once per frame
    void Update()
    {
        if (button1.GetComponent<ButtonCotroller>().buttonSwitch == 1 && button2.GetComponent<ButtonCotroller>().buttonSwitch == 1 && PlayerController.trigger == 1)
        {
            door.SetActive(false);
            message.SetActive(true);
        }
    }
}
