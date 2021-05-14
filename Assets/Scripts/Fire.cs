using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Rigidbody _lightBall;

    [SerializeField]
    private Transform _spawnPoint;

    private bool _isPlayerInRange = false;
    private float _fireTime = 10;
    private float _deltaFireTime = 0;
    
    private Transform _spawnBall;
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _player)
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == _player)
        {
            _isPlayerInRange = false;
        }
    }

    private void SpawnFire()
    {
        var spawnBall = Instantiate(_lightBall, _spawnPoint.position, Quaternion.identity);
        spawnBall.gameObject.SetActive(true); 

        spawnBall.AddForce(_player.position + Vector3.up - spawnBall.transform.position, ForceMode.Impulse);
        _spawnBall = spawnBall.transform;
    }

    private void Update()
    {
        if (_isPlayerInRange)
        {
            Vector3 direction = _player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            
            if (Physics.Raycast(ray, out var raycastHit))
            {
                transform.parent.LookAt(_player);
                if (_deltaFireTime <= 0)
                {
                    _deltaFireTime = _fireTime;
                    SpawnFire();
                    var vector = Vector3.Distance(_spawnBall.transform.position, _player.position + Vector3.up);
                    if ( Mathf.Approximately(vector, 0))
                        {
                            gameEnding.CaughtPlayer();
                        }
                    
                }
                _deltaFireTime -= Time.deltaTime;
            }
        }
    }

}
