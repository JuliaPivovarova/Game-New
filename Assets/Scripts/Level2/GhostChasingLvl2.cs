using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostChasingLvl2 : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    
    private Transform _lastKnownPosition;
    private Transform _stopPointPatrol;
    private bool _ifPlayerInRange;
    private bool _startChasing = false;

    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    public Transform[] waypoints;

    [SerializeField]
    private GameEnding _gameEnding;

    private int _currentWaypointIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AudioListener>())
        {
            _ifPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AudioListener>())
        {
            _ifPlayerInRange = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == _player)
        {
            _gameEnding.CaughtPlayer();
        }
    }

    private IEnumerator ChasePlayer(Transform lastKnownPosition, Transform lastPatrolPoint)
    {
        _navMeshAgent.SetDestination(lastKnownPosition.position);
        yield return new WaitForSeconds(2.0f);
        _navMeshAgent.SetDestination(lastPatrolPoint.position);
        _startChasing = false;
    }


    private void Start()
    {
        _navMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (!_ifPlayerInRange && !_startChasing)
        {
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
                _navMeshAgent.SetDestination(waypoints[_currentWaypointIndex].position);
            }
            _stopPointPatrol = gameObject.transform;
        }
        if (_ifPlayerInRange)
        {
            _startChasing = true;
            _navMeshAgent.SetDestination(_player.position);
            _lastKnownPosition = _player;
        }
        if (!_ifPlayerInRange && _startChasing)
        {
            StartCoroutine(ChasePlayer(_lastKnownPosition, _stopPointPatrol));
        }

    }
}
