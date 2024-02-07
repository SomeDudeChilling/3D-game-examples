using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float Speed = 10f;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public float OutOfBounds = -10f;
    public bool isOnGround = true;
    private float _horizontalInput;
    private float _forwardInput;
    private bool _isAatCheckpoint = false;
    private Vector3 _startingPosition;
    private Vector3 _checkpointPosition;
    private Rigidbody _playerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if(transform.position.y < OutOfBounds)
        {
            if(_isAatCheckpoint)
            {
                transform.position = _checkpointPosition;
            }
            else
            {
                transform.position = _startingPosition;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _forwardInput);

        _playerRigidbody.AddForce(movement * Speed);
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }   
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            _isAatCheckpoint =true;
            _checkpointPosition = other.gameObject.transform.position;
        }
        if(other.gameObject.CompareTag("EndPoint"))
        {
            _isAatCheckpoint = false;
            transform.position = _startingPosition;
        }
    }
}
