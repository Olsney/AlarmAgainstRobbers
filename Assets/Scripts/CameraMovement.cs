using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    
    [SerializeField] private float _sensitivity = 500f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        transform.Rotate(_sensitivity * -Input.GetAxis(MouseY) * Time.deltaTime * Vector3.right);
        transform.parent.Rotate(_sensitivity * Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up);
    }
}