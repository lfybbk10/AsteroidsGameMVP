using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputRouter
{
    private PlayerInput _playerInput;
    private ShipModel _model;
    private Vector2 _mousePosition;
    private Camera _camera;

    public event UnityAction OnReleaseMoveButton;

    public InputRouter(ShipModel model)
    {
        _camera = Camera.main;
        _playerInput = new PlayerInput();
        _model = model;
    }

    public void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.canceled += OnMoveButtonCanceled;
    }

    public void OnDisable()
    {
        _playerInput.Player.Move.canceled -= OnMoveButtonCanceled;
        _playerInput.Disable();
    }

    public void Update(float deltaTime)
    {
        _mousePosition = _camera.ScreenToWorldPoint(_playerInput.Player.MousePosition.ReadValue<Vector2>());
        _model.Rotate(_mousePosition);

        if (MovePerformed())
            _model.Accalerate(deltaTime);
        else
            _model.SlowDown(deltaTime);
    }

    private bool MovePerformed()
    {
        return _playerInput.Player.Move.phase == InputActionPhase.Performed;
    }

    private void OnMoveButtonCanceled(InputAction.CallbackContext obj)
    {
        _model.SetDirection();
    }
}
