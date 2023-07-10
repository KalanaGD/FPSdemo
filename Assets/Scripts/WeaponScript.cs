using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleFlashFX;
    [SerializeField] private GameObject _hitimpactFX;
    [SerializeField] private AudioClip _shootSound;

    private AudioSource _audioSource;


    [SerializeField] private float _shootRange = 300f;
   

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (Input.GetButton("Fire1"))
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

    }//Update

    private void PlayerShoot()
    {
        RaycastHit _hitInfo;
                           //origin                        direction                                      distance   
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hitInfo, _shootRange))
        {
            // Destroy(_hitInfo.transform.gameObject); //Destroy the shooted gameobject

            CreateHitImpact(_hitInfo);
        }
        else
        {
            return;
        }

    }//PlayerShoot

    private void CreateHitImpact(RaycastHit _hitInfo)
    {
        GameObject _hitImpactClone = Instantiate(_hitimpactFX, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
        Destroy(_hitImpactClone, 0.5f);
    }

}//PlayerShoot
