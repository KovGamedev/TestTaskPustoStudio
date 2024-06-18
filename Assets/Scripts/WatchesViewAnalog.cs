using System;
using UnityEngine;

public class WatchesViewAnalog : MonoBehaviour, IClockwork
{
    [SerializeField] private Transform _minutesArrow;
    [SerializeField] private Transform _hoursArrow;

    public void Tune(DateTime targetTime)
    {
        var minutesInHour = 60f;
        var hoursInClockFace = 12f;
        _minutesArrow.localRotation = Quaternion.Euler(0, 0, 360f * targetTime.Minute / minutesInHour);
        _hoursArrow.localRotation = Quaternion.Euler(0, 0, 360f * (targetTime.Hour % hoursInClockFace) / hoursInClockFace);
    }
}