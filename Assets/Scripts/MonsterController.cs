using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform monster = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private GameObject[] monsterPrefab = null;
    [SerializeField] private Transform currentMonster = null;
    [SerializeField] private float moveDistance = 2f;

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

    public void MonsterSpawn() // ���� ����
    {
        Destroy(currentMonster.gameObject); // ���� ���� �ı�

        currentMonster = Instantiate(monsterPrefab[Random.Range(0, monsterPrefab.Length)], monster.transform.position, Quaternion.identity).transform; // ���� ������ ���� ����
        currentMonster.SetParent(monster.transform); // �θ� ����

        monster.transform.position = player.position;
        int randomDirection = Random.Range(0, 2);
        Vector3 moveDirection = randomDirection == 0 ? Vector3.right : Vector3.left;
        monster.Translate(moveDirection * ((GameManager.Instance.NoteList.Count-1) * (moveDistance)));
    }
}
