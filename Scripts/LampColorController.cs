using UnityEngine;

public class LampColorController : MonoBehaviour
{
    public Renderer lampRenderer;
    public Color normalColor = Color.white;
    public Color highlightColor = Color.yellow;

    Material _materialInstance;

    void Awake()
    {
        // Garantir que cada lamp tenha material próprio
        if (lampRenderer != null)
        {
            _materialInstance = Instantiate(lampRenderer.material);
            lampRenderer.material = _materialInstance;
        }

        SetNormal();
    }

    public void SetHighlight()
    {
        if (_materialInstance != null)
            _materialInstance.color = highlightColor;
    }

    public void SetNormal()
    {
        if (_materialInstance != null)
            _materialInstance.color = normalColor;
    }
}
