using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private NoteManager theNoteManager = null;
<<<<<<< Updated upstream
    [SerializeField] private CameraManager theCameraManager = null;
    [SerializeField] private AudioManager theAudioManager = null;
    [SerializeField] private ScoreManager theScoreManager = null;
    [SerializeField] private GameOverUI theGameOverUI = null;

    [SerializeField] private Transform monster = null;
    [SerializeField] private float moveDistance = 2;
    private Vector3 moveDirection;

<<<<<<< HEAD
    [SerializeField] private SpriteRenderer spriteRenderer;

    public int hp = 3;
    [SerializeField] private Image[] life;
    [SerializeField] private GameObject Over;
    [SerializeField] private Animator anim;

    public TextMeshProUGUI countdownText;

=======
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
>>>>>>> seob
    void Update()
    {
        moveDirection = (monster.position - transform.position).normalized; // 캐릭터 방향 설정
        if (moveDirection.x > 0) { spriteRenderer.flipX = false; }
        else if (moveDirection.x < 0) { spriteRenderer.flipX = true; }
        KeyInput();
    }

    private void KeyInput() // 키 입력
    {
        // + 각각 키에 해당하는 애니메이션 로직 추가
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Attack(GameManager.Instance.CheckTiming("Up")); anim.SetTrigger("Up"); theAudioManager.PlaySFX("Up"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { Attack(GameManager.Instance.CheckTiming("Down")); anim.SetTrigger("Down"); theAudioManager.PlaySFX("Down");}
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { Attack(GameManager.Instance.CheckTiming("Left")); anim.SetTrigger("Left"); theAudioManager.PlaySFX("Left");}
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { Attack(GameManager.Instance.CheckTiming("Right")); anim.SetTrigger("Right"); theAudioManager.PlaySFX("Right");}
        else if (Input.GetKeyDown(KeyCode.Space)) { Attack(GameManager.Instance.CheckTiming("Hit")); anim.SetTrigger("Hit"); theAudioManager.PlaySFX("Hit");}
=======
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Attack(GameManager.Instance.CheckTiming("Up")); /*theAudioManager.PlaySFX("");*/ }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { Attack(GameManager.Instance.CheckTiming("Down")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { Attack(GameManager.Instance.CheckTiming("Left")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { Attack(GameManager.Instance.CheckTiming("Right")); /*theAudioManager.PlaySFX("");*/}
        else if (Input.GetKeyDown(KeyCode.Space)) { Attack(GameManager.Instance.CheckTiming("Hit")); /*theAudioManager.PlaySFX("");*/}
>>>>>>> seob
    }
    private void Attack(int judge)
    {
        if (judge == 1) // 몬스터 피격
        {
            theCameraManager.ShakeCamera(0.4f, 0.3f, 4);
            Debug.Log("Hit!!");
            transform.position = new Vector3((transform.position.x + (moveDirection.x * moveDistance)), 1.5f, transform.position.z);

        }
        else if (judge == 2) { anim.SetTrigger("Shot"); LoseLife();  theCameraManager.ShakeCamera(0.4f, 0.3f, 0); } // 몬스터 처치 실패
        else if (judge == 3) // 몬스터 처치
        {
            theCameraManager.ShakeCamera(0.4f, 0.3f, 4);
            GameManager.Instance.monsterKillCount++;
            Debug.Log("Kill~");
            theScoreManager.ScoreUpdate(theNoteManager.monsterType);
            theNoteManager.RandomNotePattern(); // 적을 처치 시 몬스터 재스폰
        }
<<<<<<< HEAD
        
=======
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
>>>>>>> seob
    }
    private void Attack(int judge) //( 1 = 성공, 2 = 실패, 3 = 처치)
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

            // 몬스터 죽음 애니메이션 작업
            theMonsterController.anim.SetTrigger("Die");
            die_Monster = theMonsterController.currentMonster;
            theMonsterController.currentMonster = null;
            Invoke("DestroyMonster", 0.5f);

            theNoteManager.RandomNotePattern(); // 적을 처치 시 몬스터 재스폰
        }
>>>>>>> Stashed changes
    }
    private void LoseLife()
    {
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
        // 라이프 감소 로직 추가
=======
>>>>>>> seob
        if (hp > 0)
        {
            hp -= 1;
            life[hp].enabled = false; // 현재 체력 이미지 비활성화
<<<<<<< HEAD
=======
            breakLife[hp].enabled = true;
>>>>>>> seob

            if (hp <= 0)
            {
                countdownText.gameObject.SetActive(false);
                theNoteManager.Note = false;
<<<<<<< HEAD
                anim.SetTrigger("Die");
                Debug.Log("플레이어 사망");
                Time.timeScale = 0;
                theGameOverUI.OnGameOver();
            }
            else { theNoteManager.Note = false; StartCoroutine(RestartGame()); }
        }
=======
                //anim.SetTrigger("Die");
                Debug.Log("플레이어 사망");
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
>>>>>>> seob
        // + 실패하는 애니메이션 로직 추가
    }

    private IEnumerator RestartGame()
    {
        countdownText.text = "3";
        countdownText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "go";
        countdownText.gameObject.SetActive(false);
        countdownText.text = "3";
        theNoteManager.Note = true;
        theNoteManager.RandomNotePattern();
    }
<<<<<<< HEAD


=======
<<<<<<< Updated upstream
=======

    void DestroyMonster()
    {
        Destroy(die_Monster.gameObject);
    }
>>>>>>> Stashed changes
>>>>>>> seob
}