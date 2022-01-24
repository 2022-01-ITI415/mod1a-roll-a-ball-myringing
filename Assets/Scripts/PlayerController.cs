using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public GameObject player;
    public GameObject door;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject gameOver;
    public GameObject tip;
    public GameObject tip1;
    public GameObject tip2;
    public GameObject message1;
    public GameObject message2;
    public GameObject menu;
    public static int trigger;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountTest();
        winTextObject.SetActive(false);
        trigger = 1;
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountTest()
    {
        countText.text = "Count: " + count.ToString() + "/12";
        if (count >= 12)
        {
            door.SetActive(false);
            message2.SetActive(true);
            tip1.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountTest();
        }

        if (other.gameObject.name == "Tip Switch")
        {
            tip1.SetActive(false);
            other.gameObject.SetActive(false);
            tip2.SetActive(true);
        }

        if (other.gameObject.name == "Message1 Trigger")
        {
            message1.SetActive(false);
            trigger = 0;
            other.gameObject.SetActive(false);
            tip2.SetActive(false);
            tip1.SetActive(true);
        }

        if (other.gameObject.CompareTag("RedWall") && gameObject.tag == "Player")
        {
            player.gameObject.SetActive(false);
            gameOver.SetActive(true);
            menu.SetActive(true);
        }

        if (other.gameObject.CompareTag("Treasure"))
        {
            other.gameObject.SetActive(false);
            message2.SetActive(false);
            tip.SetActive(false);
            winTextObject.SetActive(true);
            gameObject.tag = "Untagged";
            menu.SetActive(true);
        }
    }
}
