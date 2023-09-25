using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform monster = null;
    [SerializeField] private NoteManager theNoteManager = null;
    [SerializeField] private CameraManager theCameraManager = null;
    [SerializeField] private float moveDistance = 2;
    private Vector3 moveDirection;
    private int judge = 0;
    void Update()
    {
        KeyInput();
    }

    private void KeyInput() // Ű �Է�
    {
        moveDirection = ( monster.position - transform.position).normalized;
        // + ���� Ű�� �ش��ϴ� �ִϸ��̼� ���� �߰�
        if (Input.GetKeyDown(KeyCode.UpArrow)) { judge = GameManager.Instance.CheckTiming("Up"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { judge = GameManager.Instance.CheckTiming("Down"); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { judge = GameManager.Instance.CheckTiming("Left"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { judge = GameManager.Instance.CheckTiming("Right"); }
        else if (Input.GetKeyDown(KeyCode.Space)) { judge = GameManager.Instance.CheckTiming("Hit"); }

        if (judge == 2) { LoseLife(); }
        else if ( judge == 1) { judge = 0; transform.position += moveDirection * moveDistance; theCameraManager.ShakeCamera(); }
        else if ( judge == 3) { judge = 0; Debug.Log("Hit!!"); theCameraManager.ShakeCamera(); theNoteManager.RandomNotePattern(); } // ���� óġ �� ���� �罺��
    }

    private void LoseLife()
    {
        judge = 0;
        // + �����ϴ� �ִϸ��̼� ���� �߰�
        theNoteManager.RandomNotePattern();
    }
}


