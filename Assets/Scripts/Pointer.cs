using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pointer : MonoBehaviour
{
    [SerializeField] Unit selectedUnit;
    [SerializeField] Transform destination;
    [SerializeField] public LayerMask groundLayerMask;
    [SerializeField] public LayerMask clickableLayerMask;

    private ClickableArea prevHighlightedClickable;

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current.position.ReadValue();
        var ray = Camera.main.ScreenPointToRay(mouse);


        if (Physics.Raycast(ray, out var hitGround, 999, groundLayerMask))
        {
            transform.position = hitGround.point;

            if (Physics.Raycast(ray, out var hitClickable, 999, clickableLayerMask))
            {
                if (hitClickable.transform.TryGetComponent(out ClickableArea clickable))
                {
                    if (clickable != prevHighlightedClickable)
                    {
                        prevHighlightedClickable?.HideHighlight();
                        clickable.ShowHighlight();
                        prevHighlightedClickable = clickable;
                    }
                }
            }
            else
            {
                prevHighlightedClickable?.HideHighlight();
                prevHighlightedClickable = null;
            }


            if (Mouse.current.rightButton.isPressed)
            {
                var dest = new Destination();
                if (prevHighlightedClickable != null)
                {
                    var clickable = prevHighlightedClickable;
                    dest.position = clickable.TargetPosition;
                    dest.mode = Destination.Mode.Work;
                    dest.workplace = clickable.TargetGameObject.GetComponent<WorkPlace>();
                }
                else
                {
                    dest.position = transform.position;
                    dest.mode = Destination.Mode.Move;
                }
                selectedUnit.GoTo(dest);
                destination.position = dest.position;
            }
        }
    }
}
