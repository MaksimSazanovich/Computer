using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : Interactable
{
    [SerializeField] private MeshRenderer m_Renderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material activeMaterial;

    private void Start()
    {
        m_Renderer.material = defaultMaterial;
    }
    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }

    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition())
        {
            outline.OutlineWidth = 4;
            OnMouseEnterOnInteractableObject.Invoke();
            Debug.Log("monitor");
        }
    }

    public void SetMaterial(Material material)
    {
        m_Renderer.material = material;
    }
}
