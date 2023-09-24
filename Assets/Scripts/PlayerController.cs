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

    private void KeyInput() // 키 입력
    {
        // + 각각 키에 해당하는 애니메이션 로직 추가
        if (Input.GetKeyDown(KeyCode.UpArrow)) { judge = GameManager.Instance.CheckTiming("Up"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { judge = GameManager.Instance.CheckTiming("Down"); }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { judge = GameManager.Instance.CheckTiming("Left"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { judge = GameManager.Instance.CheckTiming("Right"); }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { judge = GameManager.Instance.CheckTiming("Hit"); }

        if (judge == 2) { LoseLife(); }
        else if ( judge == 1) { judge = 0; transform.position += Vector3.right * moveDistance; }
        else if ( judge == 3) { judge = 0; theMonsterController.MonsterSpawn(); } // 적을 처치 시 몬스터 재스폰
    }

    private void LoseLife() 
    {
        judge = 0;
        // + 실패하는 애니메이션 로직 추가
        thenoteManager.RandomNotePattern();
        theMonsterController.MonsterSpawn();
    }
}


