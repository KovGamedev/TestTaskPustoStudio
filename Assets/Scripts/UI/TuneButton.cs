using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TuneButton : ColoredButton
{
    [SerializeField] private WatchesController _watchesController;
    [Space]
    [Header("Button settings")]
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _textToEditMode;
    [SerializeField] private string _textToApplyEditing;

    private ButtonMode _currentMode;

    public override void OnPress()
    {
        base.OnPress();
        if (_currentMode == ButtonMode.EditMode)
            SwitchToWatchingMode();
        else
            SwitchToEditMode();
    }

    private void SwitchToWatchingMode()
    {
        _currentMode = ButtonMode.WatchingMode;
        _text.text = _textToEditMode;
        _watchesController.SwitchToWatchingMode();
    }

    private void SwitchToEditMode()
    {
        _currentMode = ButtonMode.EditMode;
        _text.text = _textToApplyEditing;
        _watchesController.SwitchToEditMode();
    }

    private void Start()
    {
        _currentMode = ButtonMode.WatchingMode;
        _text.text = _textToEditMode;
    }

    private enum ButtonMode
    {
        WatchingMode,
        EditMode
    }
}
