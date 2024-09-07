using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _force = 10f;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * (_speed * Time.deltaTime)) ;
        
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * (_speed * Time.deltaTime));
        
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * (_speed * Time.deltaTime));
        
        if (Input.GetKey(KeyCode.Space))
            _rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
    }
}