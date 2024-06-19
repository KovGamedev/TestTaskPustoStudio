using UnityEngine;

public class ColoredButton : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Material _pressedMaterial;

    protected bool _isPressed;

    public virtual void OnPress()
    {
        _isPressed = !_isPressed;
        _renderer.material = _isPressed ? _pressedMaterial : _normalMaterial;
    }
}
