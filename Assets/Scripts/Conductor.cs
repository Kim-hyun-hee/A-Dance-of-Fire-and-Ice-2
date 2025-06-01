using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    [Header("Components")]
    public AudioSource song;
    public PlanetController planetController;

    private float buffer;               // 재생 예약 시간 버퍼
    private double dspTimeSong;         // 곡이 실제로 시작한 dspTime
    private double dspTime;             // 현재 dspTime
    private double prevDspTime;         // 이전 프레임의 dspTime
    private double previousFrameTime;   // 이전 프레임의 unscaledTime
    private double lastReportedDspTime; // 마지막으로 관측한 AudioSettings.dspTime 값
    private float bpm = 131;            // 곡의 BPM (1분당 박자 수)


    private Coroutine startMusicCoroutine;

    private double crotchetTime;

    private void Start()
    {
        buffer = 1f;
        dspTime = AudioSettings.dspTime;
        prevDspTime = 0;
        dspTimeSong = dspTime + buffer;
        lastReportedDspTime = AudioSettings.dspTime;
        previousFrameTime = Time.unscaledTime;

        StartMusic();
    }

    public void StartMusic()
    {
        song.PlayScheduled(dspTimeSong);
    }

    private void Update()
    {
        dspTime += Time.unscaledTime - previousFrameTime;

        // dspTime이 갱신되면 재설정
        if (AudioSettings.dspTime != lastReportedDspTime)
        {
            dspTime = AudioSettings.dspTime;
            lastReportedDspTime = AudioSettings.dspTime;
        }

        // 아직 곡이 시작 안 했으면 건너뜀
        if (dspTime < dspTimeSong || !song.isPlaying)
        {
            prevDspTime = dspTime;
            previousFrameTime = Time.unscaledTime;
            return;
        }

        if (dspTime >= prevDspTime)
        {
            // 경과 시간 계산
            // dspTimeSong = 10  dspTime = 10.1  prevDspTime = 9.5 인 경우
            // deltaSongTime은 0.1이 되어야 함
            double baseTime = Math.Max(dspTimeSong, prevDspTime);
            double deltaSongTime = dspTime - baseTime;

            // 회전 각도 계산
            double targetAngle = RhythmUtils.TimeToAngleRad(deltaSongTime, bpm);
            planetController.RotateToAngle((float)targetAngle);
            prevDspTime = dspTime;
            previousFrameTime = Time.unscaledTime;
        }
        else
        {
            // 계산한 dspTime이 앞서 나가 있음
        }
    }

    public void StartMusic(Action onComplete = null, Action onSongScheduled = null)
    {
        if (startMusicCoroutine != null)
        {
            StopCoroutine(startMusicCoroutine);
        }
        startMusicCoroutine = StartCoroutine(StartMusicCo(onComplete, onSongScheduled));
    }

    private IEnumerator StartMusicCo(Action onComplete, Action onSongScheduled = null)
    {
        // 한 프레임 기다려 dspTime 안정화
        yield return null;

        dspTime = AudioSettings.dspTime;
        dspTimeSong = dspTime + buffer;

        song.UnPause();
        song.PlayScheduled(dspTimeSong);
        song.time = 0f;

        if (onSongScheduled != null)
        {
            onSongScheduled();
        }

        while (song.isPlaying)
        {
            yield return null;
        }

        if (onComplete != null)
        {
            onComplete();
        }
    }
}
