using System;
using System.Collections;
using UnityEngine;

public class RhythmUtils
{
    /// <summary>
    /// BPM을 crotchet (한 박자, 4분음표)의 길이(초)로 변환
    /// </summary>
    public static double BpmToCrotchet(double bpm)
    {
        return 60.0 / bpm;
    }

    /// <summary>
    /// 경과 시간(초)을 박자 수로 변환
    /// </summary>
    public static double TimeToBeats(double time, double bpm)
    {
        return time / BpmToCrotchet(bpm);
    }

    /// <summary>
    /// 박자 수를 시간(초)으로 변환
    /// </summary>
    public static double BeatsToTime(double beats, double bpm)
    {
        return beats * BpmToCrotchet(bpm);
    }

    /// <summary>
    /// 시간(초)을 각도(라디안)으로 변환. 1박자당 π 라디안 기준
    /// </summary>
    public static double TimeToAngleRad(double time, double bpm)
    {
        return TimeToBeats(time, bpm) * Math.PI;
    }

    /// <summary>
    /// 각도(라디안)를 시간(초)으로 변환. 1박자당 π 라디안 기준
    /// </summary>
    public static double AngleRadToTime(double angle, double bpm)
    {
        return angle / Math.PI * BpmToCrotchet(bpm);
    }
}
