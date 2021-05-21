using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _obstacle;

    [SerializeField]
    private GameEnding _gameEnding;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _player.GetComponent<Collider>())
        {
            _gameEnding.DeadPlayer ();
        }
        
        if (other == _obstacle.GetComponent<Collider>())
        {
            Destroy(gameObject);
        }
    }
}
