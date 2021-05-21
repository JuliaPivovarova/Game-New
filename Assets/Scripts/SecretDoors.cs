using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoors : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private GameObject _objectDistroy;

    private bool _isPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _player)
        {
            _isPlayerInRange = true;
            Behaviour halo = (Behaviour)gameObject.GetComponent("Halo");
            halo.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == _player)
        {
            _isPlayerInRange = false;
            //var halo = gameObject.GetComponent<Light>(halo);
            Behaviour halo = (Behaviour)gameObject.GetComponent("Halo");
            halo.enabled = false;
            
        }
    }

    private void Update()
    {        
        if (_isPlayerInRange)
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
