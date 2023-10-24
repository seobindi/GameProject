using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private CameraManager theCameraManager = null;
    [SerializeField] private PlayerController thePlayerController = null;
    [SerializeField] private NoteManager theNoteManager = null;
    //[SerializeField] private AudioManager theAudioManager = null;

    [SerializeField] private Transform monster = null;
    [SerializeField] private GameObject[] normalMonsterPrefab = null;
    [SerializeField] private GameObject[] bossMonsterPrefab = null;
    [SerializeField] public Transform currentMonster = null;

    [SerializeField] private Transform[] monsterPosition_R = null;
    [SerializeField] private Transform[] monsterPosition_L = null;
    public int randomDirection = 0;

<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private Animator anim;

=======
>>>>>>> parent of 7066fbb (20231018)
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
=======
<<<<<<< Updated upstream
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
=======
    public Animator anim;
>>>>>>> seob

    public bool Right_dir = false;

    private void OnTriggerEnter2D(Collider2D collision) // 몬스터 애니메이션 재생
    {
            if (collision.gameObject.tag == "Up")
            {
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Up");
                Debug.Log("Up Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Down")
            {
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Down");
                Debug.Log("Down Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Left")
            {
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Left");
                Debug.Log("Left Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Right")
            {
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Right");
                Debug.Log("Right Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Hit")
            {  
                theCameraManager.CameraMove(1);
                theNoteManager.TurnStart(1);
                Debug.Log("-------------------------------");
            }
            else if (collision.gameObject.tag == "Start")
            {
                theCameraManager.CameraMove(0);
            }
>>>>>>> Stashed changes
    }
    public void MonsterSpawn(string monsterType) // 몬스터 스폰
    {
        if(currentMonster != null)
            Destroy(currentMonster.gameObject); // 이전 몬스터 파괴

        int randomIndex = Random.Range(0, normalMonsterPrefab.Length); // 몬스터 종류 설정
        randomDirection = Random.Range(0, 2); // 몬스터 방향 설정
        Transform monsterPosition;

        // 몬스터 포지션 최종 결정
        if (randomDirection == 0)
        {
            monsterPosition = monsterPosition_R[GameManager.Instance.NoteList.Count-2]; // 몬스터 위치 설정
            Right_dir = true;
            thePlayerController.moveDirection = 1;
        }
        else
        {
            monsterPosition = monsterPosition_L[GameManager.Instance.NoteList.Count-2]; // 몬스터 위치 설정
            Right_dir = false;
            thePlayerController.moveDirection = -1;
        }

        if (monsterType == "Boss")
        {
            currentMonster = Instantiate(bossMonsterPrefab[randomIndex], monsterPosition.position, Quaternion.identity).transform;
            //theCameraManager.bossMode = true;
        }
        else
        {
            currentMonster = Instantiate(normalMonsterPrefab[randomIndex], monsterPosition.position, Quaternion.identity).transform;
            //theCameraManager.bossMode = false;
        }
        
        currentMonster.SetParent(monster.transform); // 부모 설정
<<<<<<< HEAD
<<<<<<< HEAD
=======

<<<<<<< Updated upstream
>>>>>>> seob
=======

>>>>>>> parent of 7066fbb (20231018)
        monster.transform.position = player.position;
        if (moveDirection == Vector3.left) { moveDirection = Vector3.right; }
        else                               { moveDirection = Vector3.left; }
        //int randomDirection = Random.Range(0, 2);
        //Vector3 moveDirection = randomDirection == 0 ? Vector3.right : Vector3.left;
        monster.Translate(moveDirection * ((GameManager.Instance.NoteList.Count) * (moveDistance)));
=======
        //몬스터 애니메이터 할당
        anim = currentMonster.GetComponent<Animator>();
        anim.SetBool("Right_dir", Right_dir);
>>>>>>> Stashed changes
    }
}