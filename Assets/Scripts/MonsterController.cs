using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private CameraManager theCameraManager = null;
    //[SerializeField] private AudioManager theAudioManager = null;

    [SerializeField] private Transform monster = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private GameObject[] normalMonsterPrefab = null;
    [SerializeField] private GameObject[] bossMonsterPrefab = null;
    [SerializeField] private Transform currentMonster = null;
    [SerializeField] private float moveDistance = 2f;

    Vector3 moveDirection = Vector3.left; // 좌, 우 반복 몬스터 방향설정( 임시 )

    private void OnTriggerEnter2D(Collider2D collision) // 몬스터 애니메이션 재생
    {
        if (collision.gameObject.tag == "Up")
        {
            /*theAudioManager.PlaySFX("");*/
            Debug.Log("Up Animation onTrigger!!");
        }
        else if (collision.gameObject.tag == "Down")
        {
            /*theAudioManager.PlaySFX("");*/
            Debug.Log("Down Animation onTrigger!!");
        }
        else if (collision.gameObject.tag == "Left")
        {
            /*theAudioManager.PlaySFX("");*/
            Debug.Log("Left Animation onTrigger!!");
        }
        else if (collision.gameObject.tag == "Right")
        {
            /*theAudioManager.PlaySFX("");*/
            Debug.Log("Right Animation onTrigger!!");
        }
        else if (collision.gameObject.tag == "Hit")
        {
            Debug.Log("-------------------------------");
        }
    }

    public void MonsterSpawn(string monsterType) // 몬스터 스폰
    {
        if (monsterType == "Boss")
        {
            Destroy(currentMonster.gameObject); // 이전 몬스터 파괴
            currentMonster = Instantiate(bossMonsterPrefab[Random.Range(0, bossMonsterPrefab.Length)],
                                            monster.transform.position, Quaternion.identity).transform; // 보스 몬스터 랜덤 스폰
            theCameraManager.bossMode = true;
        }
        else
        {
            Destroy(currentMonster.gameObject); // 이전 몬스터 파괴
            currentMonster = Instantiate(normalMonsterPrefab[Random.Range(0, normalMonsterPrefab.Length)], 
                                            monster.transform.position, Quaternion.identity).transform; // 일반 몬스터 랜덤 스폰
            theCameraManager.bossMode = false;
        }
        
        currentMonster.SetParent(monster.transform); // 부모 설정

        monster.transform.position = player.position;
        if (moveDirection == Vector3.left) { moveDirection = Vector3.right; }
        else                               { moveDirection = Vector3.left; }
        //int randomDirection = Random.Range(0, 2);
        //Vector3 moveDirection = randomDirection == 0 ? Vector3.right : Vector3.left;
        monster.Translate(moveDirection * ((GameManager.Instance.NoteList.Count) * (moveDistance)));
    }
}