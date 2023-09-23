using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NoteManager thenoteManager;
    [SerializeField] private float moveDistance = 2.5f;
    private int judge = 0;
    void Update()
    {
        KeyAssignment();
    }

    private void KeyAssignment()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { judge = GameManager.Instance.CheckTiming("Up"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { judge = GameManager.Instance.CheckTiming("Down"); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { judge = GameManager.Instance.CheckTiming("Left"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { judge = GameManager.Instance.CheckTiming("Right"); }

        if (judge == 2) { LoseLife(); }
        else if ( judge == 1) { judge = 0; transform.position += Vector3.right * moveDistance; }
    }

    private void LoseLife()
    {
        judge = 0;
        thenoteManager.RandomNotePattern();
    }
}


