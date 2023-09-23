using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Up")
        {

        }
        else if (collision.gameObject.tag == "Down")
        {

        }
        else if (collision.gameObject.tag == "Left")
        {

        }
        else if (collision.gameObject.tag == "Right")
        {

        }
    }
}
