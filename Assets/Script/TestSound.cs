using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    // public AudioClip audioClip1;
    // public AudioClip audioClip2;
    private void OnTriggerEnter(Collider other)
    {
        // AudioSource audio = GetComponent<AudioSource>();
        // audio.PlayOneShot(audioClip1);
        // audio.PlayOneShot(audioClip2);
        //
        // float lifeTime = Mathf.Max(audioClip1.length, audioClip2.length); // 생명 주기를 이런 식으로 저장하는 게 맞나???
        // GameObject.Destroy(gameObject, lifeTime);
        
        Managers.Sound.Play(Define.Sound.Effect, "Player/Player_Footstep_05");
        Managers.Sound.Play(Define.Sound.Effect, "Player/Player_Footstep_06");
    }
}
