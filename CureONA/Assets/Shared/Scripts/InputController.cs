using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public float Vertical;
	public float Horizontal;
	public Vector2 MouseInput;
	public bool Fire1;
    public bool Reload;
    public bool IsWalking;
    public bool IsSprinting;
    public bool IsCrouched;
	public bool MouseWheelUp;
	public bool MouseWheelDown;
    
    void Update()
	{
        print("Input Controller");

        Vertical = Input.GetAxis("Vertical");
		Horizontal = Input.GetAxis("Horizontal");
		MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		Fire1 = Input.GetButton("Fire1");
        Reload = Input.GetKey(KeyCode.R);
        IsWalking = Input.GetKey(KeyCode.LeftAlt);
        IsSprinting = Input.GetKey(KeyCode.LeftShift);
        IsCrouched = Input.GetKey(KeyCode.C);
		MouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
		MouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;
    }
}
