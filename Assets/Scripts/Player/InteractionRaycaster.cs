using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionRaycaster : MonoBehaviour
{
    private const float range = 100;

    private IInteractable currentInteractable;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private GameObject rayCastCamera;
    private PlayerInput input;

    private void Awake()
    {
        PlayerInput input = GetComponent<PlayerInput>();
        input.actions["Attack"].performed += _ => interact();
    }

    private void OnDestroy()
    {
        input.actions["Attack"].performed -= _ => interact();
    }

    private void interact()
    {
        currentInteractable?.Interact();
    }

    private void Update()
    {
        checkForInteract();
    }

    private void checkForInteract()
    {
        Ray _ray = new Ray(rayCastCamera.transform.position, rayCastCamera.transform.forward);
        if (!Physics.Raycast(_ray, out RaycastHit hit, range, targetMask))
        {
            clearTarget();
            return;
        }
        if (!hit.collider.TryGetComponent<IInteractable>(out var _interactable))
        {
            clearTarget();
            return;
        }
        if (hit.distance > _interactable.MaxRange)
        {
            clearTarget();
            return;
        }
        if (_interactable == currentInteractable) { return; }
        currentInteractable = _interactable;
        currentInteractable.OnHover();
    }

    private void clearTarget()
    {
        if (currentInteractable == null) { return; }
        currentInteractable.EndHover();
        currentInteractable = null;
    }
}
