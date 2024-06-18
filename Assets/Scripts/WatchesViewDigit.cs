using System;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class Watches : MonoBehaviour, IClockwork
{
    [SerializeField] private TMP_InputField _digitalWatches;

    public void Tune(DateTime targetTime)
    {
        OnUserInput(targetTime.ToString("hh:mm:ss"));
    }

    public void OnUserInput(String inputString)
    {
        var builder = new StringBuilder(string.Concat(inputString.Where(Char.IsDigit)));
        var hours = builder.Length < 2 ? builder.ToString() : builder.ToString(0, 2);
        var minutes = "";
        if (2 < builder.Length)
            minutes = 4 <= builder.Length ? builder.ToString(2, 2) : builder.ToString(2, builder.Length - 2);
        var seconds = 4 <= builder.Length ? builder.ToString(4, builder.Length - 4) : "";
        _digitalWatches.text = String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        _digitalWatches.MoveTextEnd(false);
    }
}