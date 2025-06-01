using UnityEngine;
using System;

public static class VectorUtils
{
    /// <summary>
    /// angleRadians(라디안)를 기준으로 단위 벡터 반환 (기본적으로 x축 기준 시계 반대 방향)
    /// </summary>
    public static Vector3 AngleToVector(float angleRadians)
    {
        return new Vector3(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians), 0f);
    }

    public static Vector3 AngleToVector(double angleRadians)
    {
        return new Vector3((float)Math.Cos(angleRadians), (float)Math.Sin(angleRadians), 0f);
    }

    /// <summary>
    /// angleRadians(라디안)를 기준으로 시계 방향 단위 벡터 반환
    /// </summary>
    public static Vector3 ClockwiseAngleToVector(float angleRadians)
    {
        return new Vector3(Mathf.Sin(angleRadians), Mathf.Cos(angleRadians), 0f);
    }

    public static Vector3 ClockwiseAngleToVector(double angleRadians)
    {
        return new Vector3((float)Math.Sin(angleRadians), (float)Math.Cos(angleRadians), 0f);
    }

    public static double mod(double x, double m)
    {
        return (x % m + m) % m;
    }
}