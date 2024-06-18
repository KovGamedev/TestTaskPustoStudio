using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchesController : MonoBehaviour
{
    [SerializeField] private ServerObserver _serverObserver;
    [SerializeField] private List<GameObject> _watchesViews = new();

    private WatchesModel _watchesModel = new();
    [SerializeField] private List<IClockwork> _clockworks = new();

    private void Awake() => AssignClockworks();

    private void AssignClockworks()
    {
        foreach (var view in _watchesViews)
        {
            if (view.TryGetComponent<IClockwork>(out var clockwork))
                _clockworks.Add(clockwork);
            else
                Debug.LogError("Watches view must implements IClockwork");
        }
    }

    private void Start() => SynchronizeWithServer();

    private async void SynchronizeWithServer()
    {
        _watchesModel.Time = await _serverObserver.GetServerTime();
        StartCoroutine(RunSecondsIncreasing());
    }

    private IEnumerator RunSecondsIncreasing()
    {
        var secondsInHour = 60 * 60;
        for (var i = 0; i < secondsInHour; i++) {
            yield return new WaitForSeconds(1);
            _watchesModel.AddOneSecond();
            UpdateViews();
        }
        SynchronizeWithServer();
    }


    private void UpdateViews()
    {
        foreach (var clockwork in _clockworks)
        {
            clockwork.Tune(_watchesModel.Time);
        }
    }
}
