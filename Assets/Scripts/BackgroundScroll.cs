using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private MeshRenderer BackgroundRenderer;

    private void Awake()
    {
        BackgroundRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        BackgroundRenderer.material.mainTextureOffset += new Vector2(0.025f * Time.deltaTime, 0);
    }
}
