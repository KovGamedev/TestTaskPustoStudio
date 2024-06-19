using UnityEngine;

public class AuthorButton : ColoredButton
{
    [SerializeField] private GameObject _digitalWatches;
    [SerializeField] private GameObject _authorText;

    public override void OnPress()
    {
        base.OnPress();
        _digitalWatches.SetActive(!_digitalWatches.activeSelf);
        _authorText.SetActive(!_authorText.activeSelf);
    }
}
