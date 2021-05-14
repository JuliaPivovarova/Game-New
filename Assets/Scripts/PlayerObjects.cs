using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjects : MonoBehaviour
{
    private GameObject _objectKey;
    private GameObject _objectBomb;
    private GameObject _objectDoor;
    private GameObject _objectGargoyl;
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

    private int _numberOfSpiritBombs = 0;
    private int _numberOfSpoons = 0;

    private bool m_IsKeyInRange = false;
    private bool m_IsBombInRange = false;
    private bool m_IsSpoonInRange = false;
    private bool _isKey1InHand = false;
    private bool _isKey2InHand = false;
    private bool _isKey3InHand = false;
    private bool _IsDoor1InRange = false;
    private bool _IsDoor2InRange = false;
    private bool _IsDoor3InRange = false;
    private bool _IsGargoylInRange = false;

    private Collider key1Coll;
    private Collider key2Coll;
    private Collider key3Coll;
    private Collider bomb1Coll;
    private Collider bomb2Coll;
    private Collider bomb3Coll;
    private Collider spoon1Coll;
    private Collider spoon2Coll; 
    private Collider spoon3Coll;
    private Collider spoon4Coll;
    private Collider spoon5Coll;

    private Behaviour _halo;


    private void Start()
    {
        key1Coll = _key1.GetComponent<Collider>();
        key2Coll = _key2.GetComponent<Collider>();
        key3Coll = _key3.GetComponent<Collider>();
        bomb1Coll = _bomb1.GetComponent<Collider>();
        bomb2Coll = _bomb2.GetComponent<Collider>();
        bomb3Coll = _bomb3.GetComponent<Collider>();
        spoon1Coll = _spoon1.GetComponent<Collider>();
        spoon2Coll = _spoon2.GetComponent<Collider>();
        spoon3Coll = _spoon3.GetComponent<Collider>();
        spoon4Coll = _spoon4.GetComponent<Collider>();
        spoon5Coll = _spoon5.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == key1Coll|| other == key2Coll || other == key3Coll)
        {
            if (other == key1Coll)
            {
                _objectKey = _key1;                
            }
                
            if (other == key2Coll)
            {
                _objectKey = _key2;
            }
                
            if (other == key3Coll)
            {
                _objectKey = _key3;
            }

            _halo = (Behaviour)_objectKey.GetComponent("Halo");
            _halo.enabled = true;

            m_IsKeyInRange = true;
        }

        if (other == bomb1Coll || other == bomb2Coll || other == bomb3Coll)  
        {
            if (other == bomb1Coll)
                _objectBomb = _bomb1;
            if (other == bomb2Coll)
                _objectBomb = _bomb2;
            if (other == bomb3Coll)
                _objectBomb = _bomb3;

            _halo = (Behaviour)_objectBomb.GetComponent("Halo");
            _halo.enabled = true;

            m_IsBombInRange = true;
        }

        if (other == spoon1Coll || other == spoon2Coll || other == spoon3Coll || other == spoon4Coll || other == spoon5Coll)
        {
            m_IsSpoonInRange = true;
            if (other == spoon1Coll)
                _objectSpoon = _spoon1;
            if (other == spoon2Coll)
                _objectSpoon = _spoon2;
            if (other == spoon3Coll)
                _objectSpoon = _spoon3;
            if (other == spoon4Coll)
                _objectSpoon = _spoon4;
            if (other == spoon5Coll)
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
        }
        if (_gargoyl2 != null && other == _gargoyl2.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl2;
        }
        if (_gargoyl3 != null && other == _gargoyl3.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl3;
        }
        if (_gargoyl4 != null && other == _gargoyl4.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl4;
        }
        if (_gargoyl5 != null && other == _gargoyl5.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl5;
        }
        if (_gargoyl6 != null && other == _gargoyl6.GetComponent<Collider>())
        {
            _IsGargoylInRange = true;
            _objectGargoyl = _gargoyl6;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == key1Coll || other == key2Coll || other == key3Coll)
        {
            m_IsKeyInRange = false;
            _halo = (Behaviour)other.GetComponent("Halo");
            _halo.enabled = false;
        }

        if (other == bomb1Coll || other == bomb2Coll || other == bomb3Coll)
        {
            m_IsBombInRange = false;
            _halo = (Behaviour)other.GetComponent("Halo");
            _halo.enabled = false;
        }

        if (other == spoon1Coll || other == spoon2Coll || other == spoon3Coll || other == spoon4Coll || other == spoon5Coll)
        {
            m_IsSpoonInRange = false;
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

    void Update()
    {
        if (m_IsKeyInRange)
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
                
                //Debug.Log($"key 1 - {_isKey1InHand}, key 2 - {_isKey2InHand}, key 3 - {_isKey3InHand}. Bombs - {_numberOfSpiritBombs}");
            }
        }
        if (m_IsBombInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && _objectBomb.activeInHierarchy)
            {
                _numberOfSpiritBombs++;
                _objectBomb.SetActive(false);
                //m_IsBombInRange = false;
            }
        }
        if (m_IsSpoonInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && _objectSpoon.activeInHierarchy)
            {
                _numberOfSpoons++;
                _objectSpoon.SetActive(false);
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
                _numberOfSpiritBombs--;
                //_IsGargoylInRange = false;
            }
        }
    }
}
