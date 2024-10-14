using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip shoot;
    public AudioClip click;
    public AudioClip hit_alarm;

    private AudioSource audioSource;
    private bool isAlarmPlaying = false;  // Alarmın çalınıp çalınmadığını kontrol eden değişken

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void ShootSound()
    {
        audioSource.PlayOneShot(shoot);
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(click);
    }

    public void AlarmSound()
    {
        if (!isAlarmPlaying) // Alarm çalmıyorsa çal
        {
            isAlarmPlaying = true;
            audioSource.PlayOneShot(hit_alarm);
            StartCoroutine(ResetAlarmStatus(hit_alarm.length));  // Alarmın süresine göre durumu sıfırla
        }
    }

    // Alarm süresi bitince alarmın oynadığını belirten durumu sıfırlar
    private IEnumerator ResetAlarmStatus(float duration)
    {
        yield return new WaitForSeconds(duration);
        isAlarmPlaying = false;
    }
}
