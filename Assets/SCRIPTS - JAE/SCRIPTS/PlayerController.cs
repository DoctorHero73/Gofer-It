using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5; 
    [SerializeField] private float _turnSpeed = 360;
  private Vector3 _input;


  void Update ()
  {
    GatherInput();
    Look();
  }

  void FixedUpdate()
  {
    Move();
  }


  void GatherInput()
  {
    _input = new Vector3(Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
  }

  void Look()
  {
    if (_input != Vector3.zero)
    {

        //var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        //var skewedInput = matrix.MultiplyPoint3x4(_input);

        //_input.ToIso()

        var relative = (transform.position + _input) - transform.position;
        var rot = Quaternion.LookRotation(relative, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }
  }

  void Move()
  {
    _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
  }
}
