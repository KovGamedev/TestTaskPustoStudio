using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchesController : MonoBehaviour
{
    [SerializeField] private ServerObserver _serverObserver;
    [SerializeField] private List<GameObject> _watchesViews = new();

    private WatchesModel _watchesModel = new();
    private List<IClockwork> _clockworks = new();
    private List<IEditable> _editableWathces = new();
    private Coroutine _watchesCoroutine;

    private void Awake() => FillLists();

    private void FillLists()
    {
        foreach (var view in _watchesViews)
        {
            if (view.TryGetComponent<IClockwork>(out var clockwork))
                _clockworks.Add(clockwork);
            else
                Debug.LogError($"{view.name} must implements IClockwork");

            if (view.TryGetComponent<IEditable>(out var editableWatches))
                _editableWathces.Add(editableWatches);
            else
                Debug.LogError($"{view.name} must implements IEditable");
        }
    }

    private void Start() => SynchronizeWithServer();

    private async void SynchronizeWithServer()
    {
        _watchesModel.Time = await _serverObserver.GetServerTime();
        _watchesCoroutine = StartCoroutine(CountDownHour());
    }

    private IEnumerator CountDownHour()
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

    public void SwitchToEditMode()
    {
        StopCoroutine(_watchesCoroutine);
        foreach (var watches in _editableWathces)
        {
            watches.ActivateEditMode();
        }
    }

    public void SwitchToWatchingMode()
    {
        foreach (var watches in _editableWathces)
        {
            watches.ApplyEditing(); // TODO ѕриоритезировать последние измен€ющиес€ часы?
            watches.DectivateEditMode();
        }
        _watchesCoroutine = StartCoroutine(CountDownEternity());
    }

    private IEnumerator CountDownEternity()
    {
        while (true)
        {
            Debug.Log(123);
            yield return new WaitForSeconds(1);
            _watchesModel.AddOneSecond();
            UpdateViews();
        }
    }
}
