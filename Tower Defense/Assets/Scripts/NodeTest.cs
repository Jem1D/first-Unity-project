using UnityEngine;
using UnityEngine.InputSystem;
public class NodeTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public Color hoverColor = Color.green;
    private Color defaultColor;
    private Renderer rend;
    private bool isHovering;

    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    void Update()
    {
        // Use new Input System's Mouse.current
        if (Mouse.current == null) return; // Mouse not connected

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
        {
            if (!isHovering)
            {
                isHovering = true;
                Debug.Log("Hover Start");
                rend.material.color = hoverColor;
            }
        }
        else if (isHovering)
        {
            isHovering = false;
            Debug.Log("Hover End");
            rend.material.color = defaultColor;
        }
    }
}
