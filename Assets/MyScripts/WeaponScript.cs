using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private int CurrentWeapon;

    [SerializeField] GameObject Knife;
    [SerializeField] GameObject BaseballBat;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    [SerializeField] float WaitTime = 1.0f;

    private Animator anim;
    private bool WeaponVisible = false;

    private bool Attack = true;

    void Start()
    {
        SaveScript.WeaponChange = true;
        CurrentWeapon = SaveScript.WeaponId;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.WeaponChange == true)
        {
            AssignWeapon();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (WeaponVisible == true)
            {
                WeaponVisible = false;
                anim.SetBool("Ready", false);
            }
        }
        if(CurrentWeapon >0 && CurrentWeapon < 4)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                if(WeaponVisible == false)
                {
                    WeaponVisible = true;
                    anim.SetBool("Ready", true);
                }
                else if (WeaponVisible == true)
                {
                    WeaponVisible = false;
                    anim.SetBool("Ready", false);
                }
            }
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Attack == true)
                {
                    if (CurrentWeapon == 1)
                    {
                        anim.SetInteger("WeaponStrike", 1);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                    if (CurrentWeapon == 2)
                    {
                        anim.SetInteger("WeaponStrike", 2);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                    if (CurrentWeapon == 3)
                    {
                        anim.SetInteger("WeaponStrike", 3);
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                }
            }
        }
        if(CurrentWeapon == 4)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (WeaponVisible == false)
                {
                    WeaponVisible = true;
                    anim.SetBool("GunAim", true);
                }
                else if (WeaponVisible == true)
                {
                    WeaponVisible = false;
                    anim.SetBool("GunAim", false);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Attack == true)
                {
                    if (CurrentWeapon == 4)
                    {
                        anim.SetInteger("WeaponStrike", 4   );
                        Attack = false;
                        StartCoroutine(WeaponWait());
                    }
                }
            }
        }


        //temp
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SaveScript.WeaponId = 0;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveScript.WeaponId = 1;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SaveScript.WeaponId = 2;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SaveScript.WeaponId = 3;
            AssignWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SaveScript.WeaponId = 4;
            AssignWeapon();
        }
    }
    void AssignWeapon()
    {
        SaveScript.WeaponChange = false;
        CurrentWeapon = SaveScript.WeaponId;
        if (CurrentWeapon == 0)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
        }
        if (CurrentWeapon == 1)
        {
            Knife.gameObject.SetActive(true);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.5f;
        }
        if (CurrentWeapon == 2)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(true);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.2f;
        }
        if (CurrentWeapon == 3)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(true);
            Gun.gameObject.SetActive(false);
            WaitTime = 1.6f;
        }
        if (CurrentWeapon == 4)
        {
            Knife.gameObject.SetActive(false);
            BaseballBat.gameObject.SetActive(false);
            Axe.gameObject.SetActive(false);
            Gun.gameObject.SetActive(true);
            WaitTime = 0.5f;
        }
    }
     IEnumerator WeaponWait()
    {
        yield return new WaitForSeconds(WaitTime);
        Attack = true;
        anim.SetInteger("WeaponStrike", 0);
    }
}
