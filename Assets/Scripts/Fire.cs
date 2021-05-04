using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _lightBall;

    [SerializeField]
    private Transform _spawnPoint;

    //[SerializeField]
    //private float _speed = 2;

    private bool _isPlayerInRange = false;
    private float _FireTime = 10;
    private float _deltaFireTime = 0;
    
    private GameObject _spawnBall;
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _player.transform)
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == _player.transform)
        {
            _isPlayerInRange = false;
        }
    }

    private void SpawnFire()
    {
        _spawnBall = Instantiate(_lightBall, _spawnPoint.position, Quaternion.identity);
        _spawnBall.SetActive(true);

        _spawnBall.GetComponent<Rigidbody>().AddForce(_player.transform.position + Vector3.up - _spawnBall.transform.position, ForceMode.Impulse);
    }

    void Update()
    {
        if (_isPlayerInRange)
        {
            Vector3 direction = _player.transform.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                //if (raycastHit.transform == _player)
                //{
                    transform.parent.LookAt(_player.transform);

                    if (_deltaFireTime <= 0)
                    {
                        _deltaFireTime = _FireTime;
                        SpawnFire();
                        if (Vector3.Distance(_spawnBall.transform.position, _player.transform.position + Vector3.up) == 0)
                        {
                            gameEnding.CaughtPlayer();
                        }

                    }
                    _deltaFireTime -= Time.deltaTime;
                //}
            }
        }
    }
}
