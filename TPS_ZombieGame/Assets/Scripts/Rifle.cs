using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamageOf = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 13f;
    private float nextTimeToShoot = 0f;
    public Animator animator;
    public Transform hand;

    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject WoodedEffect;

    [Header("Rifle Ammunition and Shooting")]
    private int maximumAmmunition = 32;
    public int mag = 10;
    private int presentAmmunition;
    public float reloadingTime = 1.3f;
    private bool setReloading = false;
    public PlayerScripts player;

    private void Awake() 
    {
        transform.SetParent(hand);
        presentAmmunition = maximumAmmunition;
    }


    // Update is called once per frame
    void Update()
    {   
        if (setReloading) 
        {
            return;
        }

        if (presentAmmunition <= 0)
        {
            // use StartCoroutine to call IEnumerator
            StartCoroutine(Reload());
            return;
        }

        // if it is GetButtonDown it would be single shot, this is keep shooting with a calm time of "fire charge"
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToShoot)
        {
            animator.SetBool("Fire", true);
            animator.SetBool("Idle", false);
            nextTimeToShoot = Time.time + 1f/fireCharge;
            Shoot();
        }
        else if (Input.GetButton("Fire1") && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("FireWalk", true);
            animator.SetBool("Idle", false);
        } 
        else if (Input.GetButton("Fire1") && Input.GetKey("Fire2"))
        {
            animator.SetBool("FireWalk", true);
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);
            animator.SetBool("Walk", true);
            animator.SetBool("Reloading", false);
        }
        else 
        {
            animator.SetBool("FireWalk", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Fire", false);
        }
    }

    private void Shoot()
    {
        // check for mag
        if (mag == 0)
        {
            // show ammo out text
            return;
        }

        presentAmmunition--;
        if (presentAmmunition == 0)
        {
            mag--;
        }

        // update the UI

        muzzleSpark.Play();

        RaycastHit hitInfo; // store info of what got shoot

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, shootingRange))
        {
            // log what got shoot to console
            Debug.Log(hitInfo.transform.name);

            ObjectToHit objectToHit = hitInfo.transform.GetComponent<ObjectToHit>();
            if(objectToHit != null)
            {
                objectToHit.ObjectHitDamage(giveDamageOf);
                GameObject WoodGo = Instantiate(WoodedEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(WoodGo, 1f);
            }
        }

    }

    // allows the program to yeild, runs per second
    IEnumerator Reload()
    {
        // when ammunition is 0, runs the following then back to where it was called in the previous/original function
        player.playerSpeed = 0f;
        player.playerSprint = 0f;
        setReloading = true;
        Debug.Log("reloading..");
        // play ani
        animator.SetBool("Reloading", true);
        // play reload sound
        yield return new WaitForSeconds(reloadingTime);
        
        animator.SetBool("Reloading", false);
        // reset params
        presentAmmunition = maximumAmmunition;
        player.playerSpeed = 2.1f;
        player.playerSprint = 3.2f;
        setReloading = false;
    }
}
