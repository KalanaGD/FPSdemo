using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinScript : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    private void OnTriggerStay(Collider target)
    {
        if (target.gameObject.tag == "Player")
        {

           if (Input.GetKeyDown(KeyCode.E))
           {
                PlayerController player = target.GetComponent<PlayerController>(); //handle to playercontroller script


                if(player != null) //is player in there
                {
                    player.hasCoin = true; 

                    AudioSource.PlayClipAtPoint(_coinSound,transform.position,1f); //play the coin sound

                    UIManager uiManager = GameObject.Find("Canvas").GetComponent<UIManager>(); 

                    if(uiManager != null)
                    {
                        uiManager.UpdateCoin();
                    }

                    Destroy(this.gameObject);
                }
           }
        }
    }//OnTriggerStay


    // 
    // 
    // 
    // 
    // 
    // 


}
