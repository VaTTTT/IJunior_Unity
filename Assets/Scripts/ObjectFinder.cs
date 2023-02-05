using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class ObjectFinder : MonoBehaviour
{
    [SerializeField] private Collider2D _object;
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private UnityEvent _exited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == _object)
        {
            _reached?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == _object)
        {
            _exited?.Invoke();
        }
    }
}
