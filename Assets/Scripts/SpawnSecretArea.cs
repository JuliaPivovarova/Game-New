using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSecretArea : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _spawnGhost1;

    [SerializeField]
    private Transform _spawnPoint1;

    [SerializeField]
    private GameObject _spawnGhost2;

    [SerializeField]
    private Transform _spawnPoint2;

    private bool m_IsPlayerEnter = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            m_IsPlayerEnter = true;
        }
    }

    void Update()
    {
        if (m_IsPlayerEnter)
        {
            GameObject _newGhost = Instantiate(_spawnGhost1, _spawnPoint1.position, Quaternion.identity);
            _newGhost.SetActive(true);

            GameObject _newGhost1 =Instantiate(_spawnGhost2, _spawnPoint2.position, Quaternion.identity);
            _newGhost1.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
