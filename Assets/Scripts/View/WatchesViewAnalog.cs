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
        _hoursArrow.Tune(360f * (targetTime.Hour % Const.HoursInClockFace) / Const.HoursInClockFace);
        _minutesArrow.Tune(360f * targetTime.Minute / Const.MinutesInHour);
        _secondsArrow.Tune(360f * targetTime.Second / Const.SecondsInMinute);
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
        var hours = Mathf.FloorToInt(Const.HoursInClockFace * _hoursArrow.transform.localRotation.eulerAngles.z / 360f);
        var minutes = Mathf.FloorToInt(Const.MinutesInHour * _minutesArrow.transform.localRotation.eulerAngles.z / 360f);
        var seconds = Mathf.FloorToInt(Const.SecondsInMinute * _secondsArrow.transform.localRotation.eulerAngles.z / 360f);
        var newTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hours, minutes, seconds);
        Debug.Log(newTime);
    }
}