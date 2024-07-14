using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
 //   protected Transform _tr;
    protected float _speed = 3.0f;
 //   protected float _rotSpeed = 120.0f;
    private float mouseX = 0f;
    private float mouseY = 0f;
    private readonly float mouseSens = 1f;
    private float vInput;
    private float hInput;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //    _tr.Translate(new Vector3(1, 0, 0) * Time.deltaTime * _speed);

        // управление
        /*        _tr.Translate(new Vector3(1, 0, 0) * Time.deltaTime * _speed * Input.GetAxis("Vertical"));
                _tr.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * _rotSpeed * Input.GetAxis("Horizontal"));*/
        vInput = Input.GetAxisRaw("Vertical") * _speed;
        hInput = Input.GetAxisRaw("Horizontal") * _speed;
        mouseX += Input.GetAxis("Mouse X") * mouseSens;
        mouseY += Input.GetAxis("Mouse Y") * mouseSens;
        mouseY = Mathf.Clamp(mouseY, -60, 60);
        Debug.Log(vInput);

        Quaternion rotationX = Quaternion.AngleAxis(/*hInput +*/ mouseX, Vector3.up);
        Quaternion rotationY = Quaternion.AngleAxis(mouseY, Vector3.left);
        this.transform.rotation = rotationX * rotationY;
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime + this.transform.right * hInput * Time.fixedDeltaTime);
    }
}