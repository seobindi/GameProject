using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    Vector3 moveDirection = Vector3.left; // ��, �� �ݺ� ���� ���⼳��( �ӽ� )

    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision) // ���� �ִϸ��̼� ���
    {
            if (collision.gameObject.tag == "Up")
            {
                //theCameraManager.ShakeCamera(0.1f, 0.1f, 1);
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Up");
                Debug.Log("Up Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Down")
            {
                //theCameraManager.ShakeCamera(0.1f, 0.1f, 1);
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Down");
                Debug.Log("Down Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Left")
            {
                //theCameraManager.ShakeCamera(0.1f, 0.1f, 1);
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Left");
                Debug.Log("Left Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Right")
            {
                //theCameraManager.ShakeCamera(0.1f, 0.1f, 1);
                /*theAudioManager.PlaySFX("");*/
                anim.SetTrigger("Right");
                Debug.Log("Right Animation onTrigger!!");
            }
            else if (collision.gameObject.tag == "Hit")
            {
                //theCameraManager.ShakeCamera(0.1f, 0.1f, 3);
                Debug.Log("-------------------------------");
            }
    }

    public void MonsterSpawn(string monsterType) // ���� ����
    {
        if (monsterType == "Boss")
        {
            Destroy(currentMonster.gameObject); // ���� ���� �ı�
            currentMonster = Instantiate(bossMonsterPrefab[Random.Range(0, bossMonsterPrefab.Length)],
                                            monster.transform.position, Quaternion.identity).transform; // ���� ���� ���� ����
            theCameraManager.bossMode = true;
        }
        else
        {
            Destroy(currentMonster.gameObject); // ���� ���� �ı�
            currentMonster = Instantiate(normalMonsterPrefab[Random.Range(0, normalMonsterPrefab.Length)], 
                                            monster.transform.position, Quaternion.identity).transform; // �Ϲ� ���� ���� ����
            theCameraManager.bossMode = false;
        }
        
        currentMonster.SetParent(monster.transform); // �θ� ����
        monster.transform.position = player.position;

        SpriteRenderer spriteRenderer = currentMonster.GetComponent<SpriteRenderer>();
        anim = currentMonster.GetComponent<Animator>();

        if (moveDirection == Vector3.left) { moveDirection = Vector3.right; spriteRenderer.flipX = false; }
        else                               { moveDirection = Vector3.left; spriteRenderer.flipX = true; }
        //int randomDirection = Random.Range(0, 2);
        //Vector3 moveDirection = randomDirection == 0 ? Vector3.right : Vector3.left;
        monster.Translate(moveDirection * ((GameManager.Instance.NoteList.Count) * (moveDistance)));
    }
}