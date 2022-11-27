using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableArea : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out meshRenderer);
    }

    internal void ShowHighlight()
    {
        meshRenderer.enabled = true;
    }
    internal void HideHighlight()
    {
        meshRenderer.enabled = false;
    }

    public Vector3 TargetPosition => transform.parent.position;
    public GameObject TargetGameObject => transform.parent.gameObject;
}
