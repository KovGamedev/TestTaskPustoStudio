using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowTuningConfig", menuName = "ScriptableObjects/ArrowTuningConfig")]
public class ArrowTuningConfig : ScriptableObject
{
    [SerializeField] private float _duration;
    [SerializeField] private Ease _easing;

    public float GetDuration() => _duration;

    public Ease GetEasing() => _easing;
}
