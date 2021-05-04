using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoors : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private GameObject _objectDistroy;

    bool m_IsPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _player)
        {
            m_IsPlayerInRange = true;
            Behaviour halo = (Behaviour)gameObject.GetComponent("Halo");
            halo.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == _player)
        {
            m_IsPlayerInRange = false;
            Behaviour halo = (Behaviour)gameObject.GetComponent("Halo");
            halo.enabled = false;
        }
    }

    void Update()
    {        
        if (m_IsPlayerInRange)
        {            
            if (Input.GetKeyDown(KeyCode.E) && _objectDistroy.activeInHierarchy)
            {
                _objectDistroy.SetActive(false);
                Behaviour halo = (Behaviour)gameObject.GetComponent("Halo");
                halo.enabled = false;
            }

        }            
        
    }
}
