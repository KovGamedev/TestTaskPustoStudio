using System;
using System.Text;
using TMPro;
using UnityEngine;

public class WatchesViewDigital : MonoBehaviour, IClockwork, IEditable
{
    [SerializeField] private TMP_InputField _inputField;

    private WatchesController _watchesController;

    public void Tune(DateTime targetTime)
    {
        OnUserInput(targetTime.ToString("hh:mm:ss"));
    }

    public void OnUserInput(String inputString)
    {
        var builder = new StringBuilder(StringUtils.LeaveOnlyNumbers(inputString));
        var hours = builder.Length < 2 ? builder.ToString() : builder.ToString(0, 2);
        var minutes = "";
        if (2 < builder.Length)
            minutes = 4 <= builder.Length ? builder.ToString(2, 2) : builder.ToString(2, builder.Length - 2);
        var seconds = 4 <= builder.Length ? builder.ToString(4, builder.Length - 4) : "";
        _inputField.text = String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        _inputField.MoveTextEnd(false);
    }

    public void SetController(WatchesController controller) => _watchesController = controller;

    public void ActivateEditMode() => _inputField.interactable = true;

    public void DectivateEditMode() => _inputField.interactable = false;

    public void OnEdited() => _watchesController.SetLastEditedWatches(this);

    public DateTime GetEditedTime()
    {
        var currentTime = DateTime.Now;
        var builder = new StringBuilder(StringUtils.LeaveOnlyNumbers(_inputField.text));

        var hours = Int32.Parse(builder.ToString(0, 2));
        if (Const.HoursInDay < hours)
            Debug.LogError($"Hours must be lower than {Const.HoursInDay}, provided: {hours}");

        var minutes = Int32.Parse(builder.ToString(2, 2));
        if (Const.MinutesInHour < minutes)
            Debug.LogError($"Minutes must be lower than {Const.MinutesInHour}, provided: {minutes}");

        var seconds = Int32.Parse(builder.ToString(4, 2));
        if (Const.SecondsInMinute < seconds)
            Debug.LogError($"Seconds must be lower than {Const.SecondsInMinute}, provided: {seconds}");

        return new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hours, minutes, seconds);
    }
}