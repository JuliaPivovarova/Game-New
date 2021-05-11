using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _obstacle;

    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _player.GetComponent<Collider>())
        {
            gameEnding.DeadPlayer ();
        }
        
        if (other == _obstacle.GetComponent<Collider>())
        {
            Destroy(gameObject);
        }
    }
}
