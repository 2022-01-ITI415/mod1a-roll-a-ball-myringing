using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 3f)
        {
            Follow();
        }
    }

    void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
    }
}
