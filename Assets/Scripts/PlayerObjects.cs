using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjects : MonoBehaviour
{
    private GameObject _objectKey;
    private GameObject _objectBomb;
    private GameObject _objectDoor;
    private GameObject _objectGargoyl;
    private GameObject _objectParticlesGarg;
    private GameObject _objectSpoon;

    [SerializeField]
    private GameObject _door1;

    [SerializeField]
    private GameObject _door2_open;
    [SerializeField]
    private GameObject _door2;
    [SerializeField]
    private GameObject _door3;

    [SerializeField]
    private GameObject _key1;

    [SerializeField]
    private GameObject _key2;
    [SerializeField]
    private GameObject _key3;

    [SerializeField]
    private GameObject _bomb1;
    [SerializeField]
    private GameObject _bomb2;
    [SerializeField]
    private GameObject _bomb3;

    [SerializeField]
    private GameObject _spoon1;
    [SerializeField]
    private GameObject _spoon2;
    [SerializeField]
    private GameObject _spoon3;
    [SerializeField]
    private GameObject _spoon4;
    [SerializeField]
    private GameObject _spoon5;

    [SerializeField]
    private Slider _spoonsSlider;

    [SerializeField]
    private GameObject _gargoyl1;
    [SerializeField]
    private GameObject _gargoyl2;
    [SerializeField]
    private GameObject _gargoyl3;
    [SerializeField]
    private GameObject _gargoyl4;
    [SerializeField]
    private GameObject _gargoyl5;
    [SerializeField]
    private GameObject _gargoyl6;

    [SerializeField]
    private GameObject _particlesGarg1;
    [SerializeField]
    private GameObject _particlesGarg2;
    [SerializeField]
    private GameObject _particlesGarg3;
    [SerializeField]
    private GameObject _particlesGarg4;
    [SerializeField]
    private GameObject _particlesGarg5;
    [SerializeField]
    private GameObject _particlesGarg6;

    private int _numberOfSpiritBombs = 0;
    private int _numberOfSpoons = 0;

    private bool _IsKeyInRange = false;
    private bool _IsBombInRange = false;
    private bool _IsSpoonInRange = false;
    private bool _isKey1InHand = false;
    private bool _isKey2InHand = false;
    private bool _isKey3InHand = false;
    private bool _IsDoor1InRange = false;
    private bool _IsDoor2InRange = false;
    private bool _IsDoor3InRange = false;
    private bool _IsGargoylInRange = false;

    private Collider _key1Coll;
    private Collider _key2Coll;
    private Collider _key3Coll;
    private Collider _bomb1Coll;
    private Collider _bomb2Coll;
    private Collider _bomb3Coll;
    private Collider _spoon1Coll;
    private Collider _spoon2Coll; 
    private Collider _spoon3Coll;
    private Collider _spoon4Coll;
    private Collider _spoon5Coll;

    private Behaviour _halo;


    private void Start()
    {
        _key1Coll = _key1.GetComponent<Collider>();
        _key2Coll = _key2.GetComponent<Collider>();
        _key3Coll = _key3.GetComponent<Collider>();
        _bomb1Coll = _bomb1.GetComponent<Collider>();
        _bomb2Coll = _bomb2.GetComponent<Collider>();
        _bomb3Coll = _bomb3.GetComponent<Collider>();
        _spoon1Coll = _spoon1.GetComponent<Collider>();
        _spoon2Coll = _spoon2.GetComponent<Collider>();
        _spoon3Coll = _spoon3.GetComponent<Collider>();
        _spoon4Coll = _spoon4.GetComponent<Collider>();
        _spoon5Coll = _spoon5.GetComponent<Collider>();
        _spoonsSlider.value = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _key1Coll|| other == _key2Coll || other == _key3Coll)
        {
            if (other == _key1Coll)
            {
                _objectKey = _key1;                
            }
                
            if (other == _key2Coll)
            {
                _objectKey = _key2;
            }
                
            if (other == _key3Coll)
            {
                _objectKey = _key3;
            }

            _halo = (Behaviour)_objectKey.GetComponent("Halo");
            _halo.enabled = true;

            _IsKeyInRange = true;
        }

        if (other == _bomb1Coll || other == _bomb2Coll || other == _bomb3Coll)  
        {
            if (other == _bomb1Coll)
                _objectBomb = _bomb1;
            if (other == _bomb2Coll)
                _objectBomb = _bomb2;
            if (other == _bomb3Coll)
                _objectBomb = _bomb3;

            _halo = (Behaviour)_objectBomb.GetComponent("Halo");
            _halo.enabled = true;

            _IsBombInRange = true;
        }

        if (other == _spoon1Coll || other == _spoon2Coll || other == _spoon3Coll || other == _spoon4Coll || other == _spoon5Coll)
        {
            _IsSpoonInRange = true;
            if (other == _spoon1Coll)
                _objectSpoon = _spoon1;
            if (other == _spoon2Coll)
                _objectSpoon = _spoon2;
            if (other == _spoon3Coll)
                _objectSpoon = _spoon3;
            if (other == _spoon4Coll)
                _objectSpoon = _spoon4;
            if (other == _spoon5Coll)
                _objectSpoon = _spoon5;

        }

        if (other == _door1.GetComponent<Collider>())
        {
            _IsDoor1InRange = true;
            _objectDoor = _door1;
        }

        if (other == _door2_open.GetComponent<Collider>())
        {
            _IsDoor2InRange = true;
            _objectDoor = _door2;
        }
        if (other == _door3.GetComponent<Collider>())
        {
            _IsDoor3InRange = true;
            _objectDoor = _door3;
        }

        if (_gargoyl1 != null && other == _gargoyl1.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl1;
            _objectParticlesGarg = _particlesGarg1;
        }
        if (_gargoyl2 != null && other == _gargoyl2.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl2;
            _objectParticlesGarg = _particlesGarg2;
        }
        if (_gargoyl3 != null && other == _gargoyl3.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl3;
            _objectParticlesGarg = _particlesGarg3;
        }
        if (_gargoyl4 != null && other == _gargoyl4.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl4;
            _objectParticlesGarg = _particlesGarg4;
        }
        if (_gargoyl5 != null && other == _gargoyl5.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl5;
            _objectParticlesGarg = _particlesGarg5;
        }
        if (_gargoyl6 != null && other == _gargoyl6.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl6;
            _objectParticlesGarg = _particlesGarg6;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _key1Coll || other == _key2Coll || other == _key3Coll)
        {
            _IsKeyInRange = false;
            _halo = (Behaviour)other.GetComponent("Halo");
            _halo.enabled = false;
        }

        if (other == _bomb1Coll || other == _bomb2Coll || other == _bomb3Coll)
        {
            _IsBombInRange = false;
            _halo = (Behaviour)other.GetComponent("Halo");
            _halo.enabled = false;
        }

        if (other == _spoon1Coll || other == _spoon2Coll || other == _spoon3Coll || other == _spoon4Coll || other == _spoon5Coll)
        {
            _IsSpoonInRange = false;
        }

        if (other == _door1.GetComponent<Collider>())
        {
            _IsDoor1InRange = false;
        }

        if (other == _door2.GetComponent<Collider>())
        {
            _IsDoor2InRange = false;
        }

        if (other == _door3.GetComponent<Collider>())
        {
            _IsDoor3InRange = false;
        }
        if (_gargoyl1 != null && other == _gargoyl1.GetComponent<Collider>())
        {
            _IsGargoylInRange = false;
        }
        if (_gargoyl2 != null && other == _gargoyl2.GetComponent<Collider>())
        {
            _IsGargoylInRange = false;
        }
        if (_gargoyl3 != null && other == _gargoyl3.GetComponent<Collider>())
        {
            _IsGargoylInRange = false;
        }
        if (_gargoyl4 != null && other == _gargoyl4.GetComponent<Collider>())
        {
            _IsGargoylInRange = false;
        }
        if (_gargoyl5 != null && other == _gargoyl5.GetComponent<Collider>())
        {
            _IsGargoylInRange = false;
        }
        if (_gargoyl6 != null && other == _gargoyl6.GetComponent<Collider>())
        {
            _IsGargoylInRange = false;
        }
    }

    private IEnumerator DestroyPart(GameObject _particles)
    {
        _particles.SetActive(true);
        yield return new WaitForSeconds(3f);
        _particles.SetActive(false);
    }

    private void Update()
    {
        if (_IsKeyInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && _objectKey.activeInHierarchy)
            {
                if (_objectKey == _key1)
                    _isKey1InHand = true;
                if (_objectKey == _key2)
                    _isKey2InHand = true;
                if (_objectKey == _key3)
                    _isKey3InHand = true;
                _objectKey.SetActive(false);
            }
        }
        if (_IsBombInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && _objectBomb.activeInHierarchy)
            {
                _numberOfSpiritBombs++;
                _objectBomb.SetActive(false);
            }
        }
        if (_IsSpoonInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && _objectSpoon.activeInHierarchy)
            {
                _numberOfSpoons++;
                _objectSpoon.SetActive(false);
                _spoonsSlider.value += 0.2f;
                StartCoroutine(PlayerMovment.AddSpeed());
            }
        }
        if (_IsDoor1InRange)
        {
            if (_isKey1InHand)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _door1.SetActive(false);
                }                
            }
        }
        if (_IsDoor2InRange)
        {
            if (_isKey2InHand)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _door2.SetActive(false);
                }                
            }
        }
        if (_IsDoor3InRange)
        {
            if (_isKey3InHand)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _door3.SetActive(false);
                }                
            }
        }
        if (_IsGargoylInRange)
        {
            if (_numberOfSpiritBombs > 0 && Input.GetKeyDown(KeyCode.F))
            {
                Destroy(_objectGargoyl);
                StartCoroutine(DestroyPart(_objectParticlesGarg));
                _numberOfSpiritBombs--;
            }
        }
    }
}
