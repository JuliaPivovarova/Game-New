using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 20f; 

    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private AudioSource m_AudioSource;
    private Vector3 m_Movement;
    private Quaternion m_Rotation = Quaternion.identity;
    private static float _speedPlus = 0;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
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
        

        m_Movement.Set(horizontal, 0f, vertical);
        //m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
