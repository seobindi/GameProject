using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float CameraSpeed;
    [SerializeField] private float shakeDuration = 0.1f; // 흔들림 지속 시간
    [SerializeField] private float shakeSpeed = 0.5f; // 흔들림의 세기
    [SerializeField] private int bpm = 0;
    private double currentTime = 0d;
    private float NowShakeDuration;

    //카메라 움직임
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        //transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed); // 항상 이동

        if (currentTime >= 60d / bpm) // 60/bpm = 한 비트당 시간 (120bpm이라면 한 비트당 소요 시간은 0.5초)
        {
            ShakeCamera();
            currentTime -= 60d / bpm;
        }

        

        if (NowShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeSpeed; // 랜덤한 위치 벡터 생성
            transform.localPosition = transform.position + shakeOffset; // 흔들림 효과로 카메라 위치 이동
            NowShakeDuration -= Time.deltaTime; // 흔들림 지속 시간 감소
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * CameraSpeed); // 이동 후 이동
        }
    }

    public void ShakeCamera()
    {
        NowShakeDuration = shakeDuration;
    }
}