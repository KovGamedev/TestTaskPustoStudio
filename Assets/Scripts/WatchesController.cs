using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchesController : MonoBehaviour
{
    [SerializeField] private ServerObserver _serverObserver;
    [SerializeField] private List<GameObject> _watchesViews = new();

    private WatchesModel _watchesModel = new();

    private async void Start()
    {
        _watchesModel.Time = await _serverObserver.GetServerTime();
        UpdateViews();
    }

    private void UpdateViews()
    {
        foreach (var view in _watchesViews)
        {
            if (view.TryGetComponent<IClockwork>(out var watches))
                watches.Tune(_watchesModel.Time);
            else
                Debug.LogError("Watches view must implements IClockwork");
        }
    }
}
