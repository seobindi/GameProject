using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NoteManager theNoteManager = null;
<<<<<<< Updated upstream
    [SerializeField] private CameraManager theCameraManager = null;
    //[SerializeField] private AudioManager theAudioManager = null;

    [SerializeField] private Transform monster = null;
    [SerializeField] private float moveDistance = 2;
    private Vector3 moveDirection;

=======
    [SerializeField] private MonsterController theMonsterController = null;
    //[SerializeField] private CameraManager theCameraManager = null;
    [SerializeField] private AudioManager theAudioManager = null;
    [SerializeField] private UIManager theUIManager = null;
    [SerializeField] private float moveDistance = 2.0f;
    [SerializeField] private float duration;
    public int moveDirection = 0;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform die_Monster = null;
    [SerializeField] private Image[] life;
    [SerializeField] private Image[] breakLife;
    [SerializeField] private GameObject over;
    [SerializeField] private Animator anim;
    [SerializeField] private int hp = 3;

    [SerializeField] private TextMeshProUGUI countdownText;

>>>>>>> Stashed changes
    void Update()
    {
        KeyInput();
    }

    private void KeyInput() // Ű �Է�
    {
        // + ���� Ű�� �ش��ϴ� �ִϸ��̼� ���� �߰�
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Attack(GameManager.Instance.CheckTiming("Up")); /*theAudioManager.PlaySFX("");*/ }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { Attack(GameManager.Instance.CheckTiming("Down")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { Attack(GameManager.Instance.CheckTiming("Left")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { Attack(GameManager.Instance.CheckTiming("Right")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.Space)) { Attack(GameManager.Instance.CheckTiming("Hit")); /*theAudioManager.PlaySFX("");*/}
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
=======
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        { 
            Attack(GameManager.Instance.CheckTiming("Up"));
            /*anim.SetTrigger("Up");*/ 
            theAudioManager.PlaySFX("Up"); 
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        { 
            Attack(GameManager.Instance.CheckTiming("Down")); 
            /*anim.SetTrigger("Down");*/ 
            theAudioManager.PlaySFX("Down");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        { 
            Attack(GameManager.Instance.CheckTiming("Left")); 
            /*anim.SetTrigger("Left");*/ 
            theAudioManager.PlaySFX("Left");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) 
        { 
            Attack(GameManager.Instance.CheckTiming("Right"));
            /* anim.SetTrigger("Right");*/ 
            theAudioManager.PlaySFX("Right");
        }
        else if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            Attack(GameManager.Instance.CheckTiming("Hit")); 
            /*anim.SetTrigger("Hit");*/ 
            theAudioManager.PlaySFX("Hit");
        }
    }
    private void Attack(int judge) //( 1 = ����, 2 = ����, 3 = óġ)
    {
        if (judge == 1)
        {
            Debug.Log("Hit!!");
            //transform.position = new Vector3((transform.position.x + (moveDirection.x * moveDistance)), transform.position.y, transform.position.z);
            transform.DOMoveX(transform.position.x + (moveDirection * moveDistance), duration).SetEase(Ease.OutQuad);
        }
        else if (judge == 2)
        { 
            //anim.SetTrigger("Shot");
            LoseLife();
        }
        else if (judge == 3)
        {
            Debug.Log("Kill~");
            theNoteManager.monsterKillCount++;
            theUIManager.ScoreUpdate(theNoteManager.monsterType);

            // ���� ���� �ִϸ��̼� �۾�
            theMonsterController.anim.SetTrigger("Die");
            die_Monster = theMonsterController.currentMonster;
            theMonsterController.currentMonster = null;
            Invoke("DestroyMonster", 0.5f);

            theNoteManager.RandomNotePattern(); // ���� óġ �� ���� �罺��
        }
>>>>>>> Stashed changes
    }
    private void LoseLife()
    {
<<<<<<< Updated upstream
        // ������ ���� ���� �߰�
=======
        if (hp > 0)
        {
            hp -= 1;
            life[hp].enabled = false; // ���� ü�� �̹��� ��Ȱ��ȭ
            breakLife[hp].enabled = true;

            if (hp <= 0)
            {
                countdownText.gameObject.SetActive(false);
                theNoteManager.Note = false;
                //anim.SetTrigger("Die");
                Debug.Log("�÷��̾� ���");
                Time.timeScale = 0;
                theUIManager.OnGameOver();
            }
            else 
            { 
                theNoteManager.Note = false;
                StartCoroutine(RestartGame()); 
            }
        }
>>>>>>> Stashed changes
        // + �����ϴ� �ִϸ��̼� ���� �߰�
        theNoteManager.RandomNotePattern();
    }
<<<<<<< Updated upstream
=======

    void DestroyMonster()
    {
        Destroy(die_Monster.gameObject);
    }
>>>>>>> Stashed changes
}