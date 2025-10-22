using System;
using UnityEngine;
using UnityEngine.Events;
public class Evenet : MonoBehaviour
{
    [SerializeField] UnityEvent _onEnter = default;

    public void ONpentagon()
    {
        _onEnter?.Invoke();
    }
}
