using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCotroller : MonoBehaviour
{
    public Material off;
    public Material on;
    public int buttonSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.position += new Vector3(0, -0.05f, 0);
            if (buttonSwitch == 0)
            {
                gameObject.GetComponent<MeshRenderer>().material = on;
                buttonSwitch = 1;
            }
            else if (buttonSwitch == 1)
            {
                gameObject.GetComponent<MeshRenderer>().material = off;
                buttonSwitch = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.position += new Vector3(0, 0.05f, 0);
        }
    }
}
