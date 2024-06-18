using UnityEngine;

public class WatchesViewAnalog : MonoBehaviour
{
    [SerializeField] private Transform _minutesArrow;
    [SerializeField] private Transform _hoursArrow;

    private void Start()
    {
        var now = System.DateTime.Now;
        var minutesInHour = 60f;
        var hoursInClockFace = 12f;
        _minutesArrow.localRotation = Quaternion.Euler(0, 0, 360f * now.Minute / minutesInHour);
        _hoursArrow.localRotation = Quaternion.Euler(0, 0, 360f * (now.Hour % hoursInClockFace) / hoursInClockFace);
    }
}