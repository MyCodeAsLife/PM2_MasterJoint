using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerInputController
{
    private PlayerInputActions _inputActions;
    private List<Action<InputAction.CallbackContext>> _subscribeFunctions = new();

    public PlayerInputController()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
    }

    public void SubscribeOnShoot(Action<InputAction.CallbackContext> func)
    {
        if (_subscribeFunctions.Contains(func) == false)
        {
            _subscribeFunctions.Add(func);
            _inputActions.Base.Shoot.performed += func;
        }
    }

    public void SubscribeOnReload(Action<InputAction.CallbackContext> func)
    {
        if (_subscribeFunctions.Contains(func) == false)
        {
            _subscribeFunctions.Add(func);
            _inputActions.Base.Reload.performed += func;
        }
    }

    public void UnSubscribeOnShoot(Action<InputAction.CallbackContext> func)
    {
        if (_subscribeFunctions.Contains(func))
        {
            _subscribeFunctions.Remove(func);
            _inputActions.Base.Shoot.performed -= func;
        }
    }

    public void UnSubscribeOnReload(Action<InputAction.CallbackContext> func)
    {
        if (_subscribeFunctions.Contains(func))
        {
            _subscribeFunctions.Remove(func);
            _inputActions.Base.Reload.performed -= func;
        }
    }
}
