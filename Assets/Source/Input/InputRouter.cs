using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputRouter
{
    private PlayerInput _playerInput;
    private ShipModel _model;
    private Vector2 _mousePosition;
    private Camera _camera;

    public event UnityAction OnDefoultGunShoot;
    public event UnityAction OnLazertGunShoot;

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
        _playerInput.Player.Move.performed += OnMoveButtonPerformed;
        _playerInput.Player.DefoultShoot.performed += DefoultGunShoot;
        _playerInput.Player.LazerShoot.performed += LazerGunShoot;
    }

    public void OnDisable()
    {
        _playerInput.Player.Move.canceled -= OnMoveButtonCanceled;
        _playerInput.Player.Move.performed -= OnMoveButtonPerformed;
        _playerInput.Player.DefoultShoot.performed -= DefoultGunShoot;
        _playerInput.Player.LazerShoot.performed -= LazerGunShoot;
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
        _model.StopAccalarating();
    }

    private void OnMoveButtonPerformed(InputAction.CallbackContext obj)
    {
        _model.StartAccalerating();
    }

    private void DefoultGunShoot(InputAction.CallbackContext obj)
    {
        OnDefoultGunShoot?.Invoke();
    }

    private void LazerGunShoot(InputAction.CallbackContext obj)
    {
        OnLazertGunShoot?.Invoke();
    }
}
