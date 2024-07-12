using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    protected Transform _tr;
    protected float _speed = 3.0f;
    protected float _rotSpeed = 120.0f;   

        // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //    _tr.Translate(new Vector3(1, 0, 0) * Time.deltaTime * _speed);

            // управление
        _tr.Translate(new Vector3(1, 0, 0) * Time.deltaTime * _speed * Input.GetAxis("Vertical"));
        _tr.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * _rotSpeed * Input.GetAxis("Horizontal"));
    }

}