using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private NoteManager theNoteManager = null;
    [SerializeField] private CameraManager theCameraManager = null;
    [SerializeField] private AudioManager theAudioManager = null;
    [SerializeField] private ScoreManager theScoreManager = null;
    [SerializeField] private GameOverUI theGameOverUI = null;

    [SerializeField] private Transform monster = null;
    [SerializeField] private float moveDistance = 2;
    private Vector3 moveDirection;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public int hp = 3;
    [SerializeField] private Image[] life;
    [SerializeField] private GameObject Over;
    [SerializeField] private Animator anim;

    public TextMeshProUGUI countdownText;

    void Update()
    {
        moveDirection = (monster.position - transform.position).normalized; // ĳ���� ���� ����
        if (moveDirection.x > 0) { spriteRenderer.flipX = false; }
        else if (moveDirection.x < 0) { spriteRenderer.flipX = true; }
        KeyInput();
    }

    private void KeyInput() // Ű �Է�
    {
        // + ���� Ű�� �ش��ϴ� �ִϸ��̼� ���� �߰�
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Attack(GameManager.Instance.CheckTiming("Up")); anim.SetTrigger("Up"); theAudioManager.PlaySFX("Up"); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { Attack(GameManager.Instance.CheckTiming("Down")); anim.SetTrigger("Down"); theAudioManager.PlaySFX("Down");}
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) { Attack(GameManager.Instance.CheckTiming("Left")); anim.SetTrigger("Left"); theAudioManager.PlaySFX("Left");}
        else if (Input.GetKeyDown(KeyCode.RightArrow)) { Attack(GameManager.Instance.CheckTiming("Right")); anim.SetTrigger("Right"); theAudioManager.PlaySFX("Right");}
        else if (Input.GetKeyDown(KeyCode.Space)) { Attack(GameManager.Instance.CheckTiming("Hit")); anim.SetTrigger("Hit"); theAudioManager.PlaySFX("Hit");}
    }
    private void Attack(int judge)
    {
        if (judge == 1) // ���� �ǰ�
        {
            theCameraManager.ShakeCamera(0.4f, 0.3f, 4);
            Debug.Log("Hit!!");
            transform.position = new Vector3((transform.position.x + (moveDirection.x * moveDistance)), 1.5f, transform.position.z);

        }
        else if (judge == 2) { anim.SetTrigger("Shot"); LoseLife();  theCameraManager.ShakeCamera(0.4f, 0.3f, 0); } // ���� óġ ����
        else if (judge == 3) // ���� óġ
        {
            theCameraManager.ShakeCamera(0.4f, 0.3f, 4);
            GameManager.Instance.monsterKillCount++;
            Debug.Log("Kill~");
            theScoreManager.ScoreUpdate(theNoteManager.monsterType);
            theNoteManager.RandomNotePattern(); // ���� óġ �� ���� �罺��
        }
        
    }

    private void LoseLife()
    {
        if (hp > 0)
        {
            hp -= 1;
            life[hp].enabled = false; // ���� ü�� �̹��� ��Ȱ��ȭ

            if (hp <= 0)
            {
                countdownText.gameObject.SetActive(false);
                theNoteManager.Note = false;
                anim.SetTrigger("Die");
                Debug.Log("�÷��̾� ���");
                Time.timeScale = 0;
                theGameOverUI.OnGameOver();
            }
            else { theNoteManager.Note = false; StartCoroutine(RestartGame()); }
        }
        // + �����ϴ� �ִϸ��̼� ���� �߰�
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


}