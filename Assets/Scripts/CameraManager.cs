using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraSpeed = 0.0f;
    [SerializeField] private float shakeDuration = 0.1f; // 흔들림 지속 시간
    [SerializeField] private float shakeSpeed = 0.5f; // 흔들림의 세기
    [SerializeField] private float yOffset = 0.0f;
    [SerializeField] private int bpm = 0;
    private double currentTime = 0d;
    private float nowShakeDuration = 0.0f;
    public bool bossMode = false;
    private Vector3 targetPosition;

    //카메라 움직임
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);

        if(!bossMode) // 비보스 모드
        {
            targetPosition = Target.position;
            targetPosition.y += yOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed); // 항상 이동
            mainCamera.orthographicSize = 5.0f;
        }
        else // 보스 모드
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
            mainCamera.orthographicSize = 7.0f;
        }

        if (currentTime >= 60d / bpm) // 60/bpm = 한 비트당 시간 (120bpm이라면 한 비트당 소요 시간은 0.5초)
        {
            ShakeCamera();
            currentTime -= 60d / bpm;
        }

        //카메라 흔들림
        if (nowShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeSpeed; // 랜덤한 위치 벡터 생성
            transform.localPosition = transform.position + shakeOffset; // 흔들림 효과로 카메라 위치 이동
            nowShakeDuration -= Time.deltaTime; // 흔들림 지속 시간 감소
        }
        //else
        //{
        //    transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed); // 이동 후 이동
        //}
    }

    public void ShakeCamera()
    {
        nowShakeDuration = shakeDuration;
    }
}