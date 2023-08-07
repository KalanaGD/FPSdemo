using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                PlayerController player = target.GetComponent<PlayerController>();


                if (player != null)
                {
                    if(player.hasCoin == true)
                    {
                        player.hasCoin = false;

                        UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                        if (uiManager != null)
                        {
                            uiManager.RemoveCoin();
                        }

                        _audioSource.Play();
                    }
                    else
                    {
                        print("go away");
                    }

                }

            }
        }

    }







}//class



// check for E key
// check if player has coin
// remove the coin from player
// update inventry display
// play win sound

// debug go away

