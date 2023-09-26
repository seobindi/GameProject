using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform monster = null;
    [SerializeField] private NoteManager theNoteManager = null;
    [SerializeField] private CameraManager theCameraManager = null;
    //[SerializeField] private AudioManager theAudioManager = null;
    [SerializeField] private float moveDistance = 2;
    private Vector3 moveDirection;

    void Update()
    {
        KeyInput();
    }

    private void KeyInput() // Ű �Է�
    {
        // + ���� Ű�� �ش��ϴ� �ִϸ��̼� ���� �߰�
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Attack(GameManager.Instance.CheckTiming("Up")); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { Attack(GameManager.Instance.CheckTiming("Down")); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { Attack(GameManager.Instance.CheckTiming("Left")); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { Attack(GameManager.Instance.CheckTiming("Right")); }
        else if (Input.GetKeyDown(KeyCode.Space)) { Attack(GameManager.Instance.CheckTiming("Hit")); }
    }
    private void Attack(int judge)
    {

        if (judge == 1) // ���� �ǰ�
        {
            Debug.Log("Hit!!");
            moveDirection = (monster.position - transform.position).normalized; // ĳ���� ���� ����
            transform.position += moveDirection * moveDistance;
        }
        else if (judge == 2) { LoseLife(); } // ���� óġ ����
        else if (judge == 3) // ���� óġ
        {
            GameManager.Instance.monsterKillCount++;
            Debug.Log("Kill~");
            theNoteManager.RandomNotePattern(); // ���� óġ �� ���� �罺��
        }
        theCameraManager.ShakeCamera();
        //theAudioManager.PlaySFX(""); // ȿ���� ����
    }

    private void LoseLife()
    {
        // ������ ���� ���� �߰�
        // + �����ϴ� �ִϸ��̼� ���� �߰�
        theNoteManager.RandomNotePattern();
    }
}