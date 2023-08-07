using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoText;
    [SerializeField] private GameObject coinImage;

    public void UpdateAmmo(int count)
    {
        _ammoText.text = " Ammo : " + count.ToString();

    }//UpdateAmmo
    public void UpdateCoin()
    {
        coinImage.SetActive(true);
       
    }//UpdateCoin

    public void RemoveCoin()
    {
        coinImage.SetActive(false);

    }//RemoveCoin




}//Class


