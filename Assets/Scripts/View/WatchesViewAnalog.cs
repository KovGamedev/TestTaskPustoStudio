using System;
using UnityEngine;

public class WatchesViewAnalog : MonoBehaviour, IClockwork, IEditable
{
    [SerializeField] private Arrow _hoursArrow;
    [SerializeField] private Arrow _minutesArrow;
    [SerializeField] private Arrow _secondsArrow;

    private WatchesController _watchesController;

    public void Tune(DateTime targetTime)
    {
        var hoursInClockFace = 12f;
        _hoursArrow.Tune(360f * (targetTime.Hour % hoursInClockFace) / hoursInClockFace);

        var minutesInHour = 60f;
        _minutesArrow.Tune(360f * targetTime.Minute / minutesInHour);

        var secondsInMinute = 60f;
        _secondsArrow.Tune(360f * targetTime.Second / secondsInMinute);
    }

    public void Setcontroller(WatchesController controller) => _watchesController = controller;

    public void ActivateEditMode()
    {
        _hoursArrow.GetCollider().enabled = true;
        _minutesArrow.GetCollider().enabled = true;
        _secondsArrow.GetCollider().enabled = true;
    }

    public void DectivateEditMode()
    {
        _hoursArrow.GetCollider().enabled = false;
        _minutesArrow.GetCollider().enabled = false;
        _secondsArrow.GetCollider().enabled = false;
    }

    public void ApplyEditing()
    {
        var currentTime = DateTime.Now;

        var hoursInClockFace = 12f;
        var hours = Mathf.FloorToInt(hoursInClockFace * _hoursArrow.transform.localRotation.eulerAngles.z / 360f);
        var minutesInHour = 60f;
        var minutes = Mathf.FloorToInt(minutesInHour * _minutesArrow.transform.localRotation.eulerAngles.z / 360f);
        var secondsInMinute = 60f;
        var seconds = Mathf.FloorToInt(secondsInMinute * _secondsArrow.transform.localRotation.eulerAngles.z / 360f);
        var newTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hours, minutes, seconds);
        Debug.Log(newTime);
    }
}