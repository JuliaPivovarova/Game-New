using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float _turnSpeed = 20f; 


    private Animator _animator;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;
    private static float _speedPlus = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _speedPlus = 0;
    }

    public static IEnumerator AddSpeed()
    {
        _speedPlus += 3.0f;
        //Debug.Log("Started");
        yield return new WaitForSeconds(5.0f);
        _speedPlus = 0;         
    }
    
    private void FixedUpdate()
    {
        float horizontal = (2 + _speedPlus) * Input.GetAxis("Horizontal");
        float vertical = (2 + _speedPlus) * Input.GetAxis("Vertical");
        

        _movement.Set(horizontal, 0f, vertical);
        //m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        _animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, _turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(_rotation);
    }
}
