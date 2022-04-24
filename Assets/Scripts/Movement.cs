using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _rotateSpeed;
     
    private Rigidbody _rb;
    private float _vertical, _horizontal;
        
    private void Awake() => 
        _rb = GetComponent<Rigidbody>();

    private void Update()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up * (_horizontal * _rotateSpeed));
    }

    private void FixedUpdate() => 
        _rb.velocity = transform.forward * (_vertical * _speed);
}