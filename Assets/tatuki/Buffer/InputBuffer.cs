using System;

using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ���͂��Ǘ�����N���X
/// </summary>
[RequireComponent (typeof(PlayerInput))]
public class InputBuffer : MonoBehaviour
{
    public event Action<Vector2> OnMove;
  
    private PlayerInput _playerinput;
    public Vector2 CurrentMoveInput { get; private set; }

    InputAction _moveAction;
    private void Awake()
    {
        _playerinput = GetComponent<PlayerInput> ();
        _moveAction = _playerinput.actions["Move"];
    }

    private void OnEnable()
    {
        _moveAction.performed += OnMoveAction;
        _moveAction.canceled += OnMoveAction;
       
    }

    private void OnDisable()
    {
        _moveAction.performed -= OnMoveAction;
        _moveAction.canceled -= OnMoveAction;
    }

    /// <summary>
    /// ���͈ړ���ʒm����
    /// </summary>
    /// <param name="ctx"></param>
    private void OnMoveAction(InputAction.CallbackContext ctx)
    {
        Vector2 input  = ctx.ReadValue<Vector2>();
       
        OnMove?.Invoke(input);
    }


}
