using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleFlashFX;
    [SerializeField] private GameObject _hitimpactFX;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private float _shootRange = 300f;
    [SerializeField] private Camera _fpCamera;

    private AudioSource _audioSource;

    private bool _isZoomedIn;
    private float _zoomedInView = 30f;
    private float _normalView = 60f;

    [SerializeField] private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool _isReloading;

    private UIManager _uIManager;

 
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();


        _currentAmmo = _maxAmmo;

    }//Start

    void Update()
    { 
        Aiming();

        if (Input.GetButton("Fire1") && _currentAmmo > 0) 
        {
            PlayerShoot();

            _muzzleFlashFX.Play();
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_shootSound);
            }
        }
        else
        {
            _muzzleFlashFX.Stop();
            _audioSource.Stop();
        }

     

        if (Input.GetKeyDown(KeyCode.R)&& _isReloading == false)
        {
            StartCoroutine(WeaponReload());
            _isReloading = true;
          
        }

    }//Update

    private void Aiming()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(_isZoomedIn == false)
            {
                _fpCamera.fieldOfView = _zoomedInView;
                _isZoomedIn = true;
            }
            else
            {
                _fpCamera.fieldOfView = _normalView;
                _isZoomedIn = false;
            }
        }

    }//Aiming

    private void PlayerShoot()
    {
        _currentAmmo--;

        _uIManager.UpdateAmmo(_currentAmmo);

        RaycastHit _hitInfo;

                           //origin                        direction                                      distance   
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hitInfo, _shootRange))
        {
            ///Destroy(_hitInfo.transform.gameObject); //Destroy the shots were hits gameobject.

            CreateHitImpact(_hitInfo); // visual effect where shots were fired.
        }
        else
        {
            return;
        }

    }//PlayerShoot

    private void CreateHitImpact(RaycastHit _hitInfo)
    {
        //instantiate the hitmaker effect
        GameObject _hitImpactClone = Instantiate(_hitimpactFX, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal)); 

        Destroy(_hitImpactClone, 0.5f); // destroy cloned hit marker.

    }//CreateHitImpact

    private IEnumerator WeaponReload()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _isReloading = false;

        _uIManager.UpdateAmmo(_currentAmmo);


    }//WeaponReload

}//class

