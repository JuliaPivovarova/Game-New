using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostChasing : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    
    private Transform _lastKnownPosition;
    private Transform _stopPointPatrol;
    private bool _ifPlayerInRange;
    private bool _startChasing = false;

    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public GameEnding gameEnding;

    int m_CurrentWaypointIndex;

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
            gameEnding.CaughtPlayer();
        }
    }

    private IEnumerator ChasePlayer(Transform lastKnownPosition, Transform lastPatrolPoint)
    {
        navMeshAgent.SetDestination(lastKnownPosition.position);
        yield return new WaitForSeconds(2.0f);
        navMeshAgent.SetDestination(lastPatrolPoint.position);
        _startChasing = false;
    }


    private void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (!_ifPlayerInRange && !_startChasing)
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            _stopPointPatrol = gameObject.transform;
        }
        if (_ifPlayerInRange)
        {
            _startChasing = true;
            navMeshAgent.SetDestination(_player.position);
            _lastKnownPosition = _player;
        }
        if (!_ifPlayerInRange && _startChasing)
        {
            StartCoroutine(ChasePlayer(_lastKnownPosition, _stopPointPatrol));
        }

    }
}
