using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject InventoryMenu;
    [SerializeField] GameObject KnifeImage;
    [SerializeField] GameObject KnifeButton;
    [SerializeField] GameObject BatImage;
    [SerializeField] GameObject BatButton;
    [SerializeField] GameObject AxeImage;
    [SerializeField] GameObject AxeButton;
    [SerializeField] GameObject GunImage;
    [SerializeField] GameObject GunButton;
    [SerializeField] GameObject KnifeBlank;
    [SerializeField] GameObject BatBlank;
    [SerializeField] GameObject AxeBlank;
    [SerializeField] GameObject GunBlank;


    private bool InventoryActive = false;
    private bool ExitInventory = true;
    void Start()
    {
        InventoryMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(InventoryActive == false)
            {
                ExitInventory = false;
                StartCoroutine(OpenInventory());

            }
            else if (InventoryActive == true)
            {
                if (ExitInventory == true)
                {

                    Time.timeScale = 1f;
                    InventoryMenu.gameObject.SetActive(false);
                    InventoryActive = false;
                    Cursor.visible = false;
                }
            }
        }
    }

    public void ChooseKnife()
    {
        SaveScript.WeaponId = 1;
        SaveScript.WeaponChange = true;
    }
    public void ChooseBat()
    {
        SaveScript.WeaponId = 2;
        SaveScript.WeaponChange = true;
    }
    public void ChooseAxe()
    {
        SaveScript.WeaponId = 3;
        SaveScript.WeaponChange = true;
    }
    public void ChooseGun()
    {
        SaveScript.WeaponId = 4;
        SaveScript.WeaponChange = true;
    }

    IEnumerator OpenInventory()
    {
        InventoryMenu.gameObject.SetActive(true);
        InventoryCheck(); 
        InventoryActive = true;
        Cursor.visible = true;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        ExitInventory = true;
    }
    void InventoryCheck()
    {
        if(SaveScript.HaveKnife == true)
        {
            KnifeBlank.gameObject.SetActive(false);
            KnifeImage.gameObject.SetActive(true);
            KnifeButton.gameObject.SetActive(true);
        }
        if (SaveScript.HaveKnife == false)
        {
            KnifeBlank.gameObject.SetActive(true);
            KnifeImage.gameObject.SetActive(false);
            KnifeButton.gameObject.SetActive(false);
        }
        if (SaveScript.HaveBat == true)
        {
            BatBlank.gameObject.SetActive(false);
            BatImage.gameObject.SetActive(true);
            BatButton.gameObject.SetActive(true);
        }
        if (SaveScript.HaveBat == false)
        {
            BatBlank.gameObject.SetActive(true);
            BatImage.gameObject.SetActive(false);
            BatButton.gameObject.SetActive(false);
        }
        if (SaveScript.HaveAxe == true)
        {
            AxeBlank.gameObject.SetActive(false);
            AxeImage.gameObject.SetActive(true);
            AxeButton.gameObject.SetActive(true);
        }
        if (SaveScript.HaveAxe == false)
        {
            AxeBlank.gameObject.SetActive(true);
            AxeImage.gameObject.SetActive(false);
            AxeButton.gameObject.SetActive(false);
        }
        if (SaveScript.HaveGun == true)
        {
            GunBlank.gameObject.SetActive(false);
            GunImage.gameObject.SetActive(true);
            GunButton.gameObject.SetActive(true);
        }
        if (SaveScript.HaveGun == false)
        {
            GunBlank.gameObject.SetActive(true);
            GunImage.gameObject.SetActive(false);
            GunButton.gameObject.SetActive(false);
        }
    }
}
