using UnityEngine;

public class Controls : MonoBehaviour
{
    private InputActions _inputActions;

    private void OnEnable() { _inputActions = new InputActions(); }

    private void OnDisable() { _inputActions.Disable(); }

    private void OnDestroy() { _inputActions.Dispose(); }
}