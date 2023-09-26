using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform monster = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private GameObject[] normalMonsterPrefab = null;
    [SerializeField] private GameObject[] bossMonsterPrefab = null;
    [SerializeField] private Transform currentMonster = null;
    [SerializeField] private float moveDistance = 2f;

    Vector3 moveDirection = Vector3.left; // ��, �� �ݺ� ���� ���⼳��( �ӽ� )

    private void OnTriggerEnter2D(Collider2D collision) // ���� �ִϸ��̼� ���
    {
        if (collision.gameObject.tag == "Up")
        {
            Debug.Log("Up Animation onTrigger!!");
        }
        else if (collision.gameObject.tag == "Down")
        {
            Debug.Log("Down Animation onTrigger!!");
        }
        else if (collision.gameObject.tag == "Left")
        {
            Debug.Log("Left Animation onTrigger!!");
        }
        else if (collision.gameObject.tag == "Right")
        {
            Debug.Log("Right Animation onTrigger!!");
        }
    }

    public void MonsterSpawn(string monsterType) // ���� ����
    {
        if (monsterType == "Boss")
        {
            Destroy(currentMonster.gameObject); // ���� ���� �ı�
            currentMonster = Instantiate(bossMonsterPrefab[Random.Range(0, bossMonsterPrefab.Length)],
                                            monster.transform.position, Quaternion.identity).transform; // ���� ���� ���� ����
        }
        else
        {
            Destroy(currentMonster.gameObject); // ���� ���� �ı�
            currentMonster = Instantiate(normalMonsterPrefab[Random.Range(0, normalMonsterPrefab.Length)], 
                                            monster.transform.position, Quaternion.identity).transform; // �Ϲ� ���� ���� ����
        }
        
        currentMonster.SetParent(monster.transform); // �θ� ����

        monster.transform.position = player.position;
        if (moveDirection == Vector3.left) { moveDirection = Vector3.right; }
        else                               { moveDirection = Vector3.left; }
        //int randomDirection = Random.Range(0, 2);
        //Vector3 moveDirection = randomDirection == 0 ? Vector3.right : Vector3.left;
        monster.Translate(moveDirection * ((GameManager.Instance.NoteList.Count) * (moveDistance)));
    }
}