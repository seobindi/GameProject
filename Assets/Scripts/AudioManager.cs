using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    //public static AudioManager instance; // 싱글톤으로 할지 후에 결정

    [SerializeField] Sound[] sfx = null;
    [SerializeField] Sound[] bgm = null;
    [SerializeField] AudioSource bgmPlayer = null;
    [SerializeField] AudioSource[] sfxPlayer = null;

    //private void Awake()
    //{
    //    instance = this;
    //}
    private void Start()
    {
        PlayBGM("80BPM"); // BGM 실행
    }
    public void PlayBGM(string bgmName)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (bgmName == bgm[i].name)
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.Play();
            }
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfxName == sfx[i].name)
            {
                for (int j = 0; j < sfxPlayer.Length; j++)
                {
<<<<<<< Updated upstream
=======
                    // SFXPlayer에서 재생 중이지 않은 Audio Source를 발견했다면 
>>>>>>> Stashed changes
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
<<<<<<< Updated upstream
                Debug.Log("All audio is in use.");
                return;
=======
                Debug.Log("모든 오디오 플레이어가 재생중입니다.");
                return;

                //if (!sfxPlayer.isPlaying)
                //{
                //    sfxPlayer.clip = sfx[i].clip;
                //    sfxPlayer.Play();
                //    return;
                //}
                //else
                //{
                //    sfxPlayer.Stop();
                //    sfxPlayer.clip = sfx[i].clip;
                //    sfxPlayer.Play();
                //    return;
                //}
>>>>>>> Stashed changes
            }
        }
        Debug.Log("The name could not be found.");
        return;
    }
}