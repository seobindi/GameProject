using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NoteManager thenoteManager = null;
    [SerializeField] private MonsterController theMonsterController = null;
    [SerializeField] private float moveDistance = 2;
    private int judge = 0;
    void Update()
    {
        KeyInput();
    }

    private void KeyInput() // Ű �Է�
    {
        // + ���� Ű�� �ش��ϴ� �ִϸ��̼� ���� �߰�
        if (Input.GetKeyDown(KeyCode.UpArrow)) { judge = GameManager.Instance.CheckTiming("Up"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { judge = GameManager.Instance.CheckTiming("Down"); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { judge = GameManager.Instance.CheckTiming("Left"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { judge = GameManager.Instance.CheckTiming("Right"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { judge = GameManager.Instance.CheckTiming("Hit"); }

        if (judge == 2) { LoseLife(); }
        else if ( judge == 1) { judge = 0; transform.position += Vector3.right * moveDistance; }
        else if ( judge == 3) { judge = 0; theMonsterController.MonsterSpawn(); } // ���� óġ �� ���� �罺��
    }

    private void LoseLife() 
    {
        judge = 0;
        // + �����ϴ� �ִϸ��̼� ���� �߰�
        thenoteManager.RandomNotePattern();
        theMonsterController.MonsterSpawn();
    }
}


