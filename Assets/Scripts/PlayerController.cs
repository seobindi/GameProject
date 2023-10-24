using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NoteManager theNoteManager = null;
    [SerializeField] private CameraManager theCameraManager = null;
    //[SerializeField] private AudioManager theAudioManager = null;

    [SerializeField] private Transform monster = null;
    [SerializeField] private float moveDistance = 2;
    private Vector3 moveDirection;

    void Update()
    {
        KeyInput();
    }

    private void KeyInput() // 키 입력
    {
        // + 각각 키에 해당하는 애니메이션 로직 추가
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Attack(GameManager.Instance.CheckTiming("Up")); /*theAudioManager.PlaySFX("");*/ }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { Attack(GameManager.Instance.CheckTiming("Down")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { Attack(GameManager.Instance.CheckTiming("Left")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { Attack(GameManager.Instance.CheckTiming("Right")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.Space)) { Attack(GameManager.Instance.CheckTiming("Hit")); /*theAudioManager.PlaySFX("");*/}
    }
    private void Attack(int judge)
    {
        if (judge == 1) // 몬스터 피격
        {
            Debug.Log("Hit!!");
            moveDirection = (monster.position - transform.position).normalized; // 캐릭터 방향 설정
            transform.position += moveDirection * moveDistance;
        }
        else if (judge == 2) { LoseLife(); } // 몬스터 처치 실패
        else if (judge == 3) // 몬스터 처치
        {
            GameManager.Instance.monsterKillCount++;
            Debug.Log("Kill~");
            theNoteManager.RandomNotePattern(); // 적을 처치 시 몬스터 재스폰
        }
        theCameraManager.ShakeCamera();
    }

    private void LoseLife()
    {
        // 라이프 감소 로직 추가
        // + 실패하는 애니메이션 로직 추가
        theNoteManager.RandomNotePattern();
    }
}