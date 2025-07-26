using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float panSpeed = 30f;
    public float panBoxThickness = 10f;
    public float scrollSpeed = 5f;

    private bool doMovement = true;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (Keyboard.current.wKey.isPressed || Mouse.current.position.y.ReadValue() >= Screen.height - panBoxThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Keyboard.current.sKey.isPressed || Mouse.current.position.y.ReadValue() <= panBoxThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Keyboard.current.aKey.isPressed || Mouse.current.position.x.ReadValue() <= panBoxThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Keyboard.current.dKey.isPressed || Mouse.current.position.x.ReadValue() >= Screen.height - panBoxThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Mouse.current.scroll.y.ReadValue();
        // Debug.Log(scroll);
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, 10f, 110f);
        transform.position = pos;

    }
}
