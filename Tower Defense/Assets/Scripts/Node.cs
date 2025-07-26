using UnityEngine;
using UnityEngine.InputSystem;
public class Node : MonoBehaviour
{
    // public Color hoverColor = Color.green;
    // private Renderer rend;
    // private Color startColor;

    // void Start()
    // {
    //     rend = GetComponent<Renderer>();
    //     startColor = rend.material.color;
    //     Debug.Log(hoverColor.ToString());
    // }
    // void OnMouseEnter()
    // {
    //     Debug.Log("Mouse Enter");
    //     rend.material.color = hoverColor;
    // }
    // void OnMouseExit()
    // {
    //     Debug.Log("Mouse Exit");
    //     rend.material.color = startColor;
    // }

    public Color hoverColor = Color.green;
    public Vector3 offsetPosition;
    private Color defaultColor;
    private Renderer rend;
    private bool isHovering;
    private GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cant Build");
            return;
        }
        Debug.Log("Can Build");
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + offsetPosition, transform.rotation);
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
                rend.material.color = hoverColor;
            }
            if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    if (turret != null)
                    {
                        Debug.Log("Can't Build Here");
                        return;
                    }

                    // Debug.Log("Can Build");
                    GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
                    turret = Instantiate(turretToBuild, transform.position + offsetPosition, transform.rotation);
                }
        }
        else if (isHovering)
        {
            isHovering = false;
            rend.material.color = defaultColor;
        }
    }
}
