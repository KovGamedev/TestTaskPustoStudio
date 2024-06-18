using System;
using UnityEngine;

public class WatchesViewAnalog : MonoBehaviour, IClockwork
{
    [SerializeField] private Arrow _hoursArrow;
    [SerializeField] private Arrow _minutesArrow;
    [SerializeField] private Arrow _secondsArrow;

    public void Tune(DateTime targetTime)
    {
        var hoursInClockFace = 12f;
        _hoursArrow.Tune(360f * (targetTime.Hour % hoursInClockFace) / hoursInClockFace);

        var minutesInHour = 60f;
        _minutesArrow.Tune(360f * targetTime.Minute / minutesInHour);

        var secondsInMinute = 60f;
        _secondsArrow.Tune(360f * targetTime.Second / secondsInMinute);
    }
}