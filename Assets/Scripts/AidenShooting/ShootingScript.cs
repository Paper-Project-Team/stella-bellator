using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private Vector2 firePoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float fireOffset;
    private GameObject tempObject;
    [SerializeField] private GameObject currentWeapon;
    private Rigidbody2D projBody;
    private int weaponPos = 0;
    private GameObject[] weapons;
    private MoveScript mover;
    [SerializeField]private GameObject projectilePrefab;
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    


    void Start()
    {
        
        //weapons = GameObject.FindGameObjectsWithTag("Weapon");
        //currentWeapon = weapons[0];
        mover = GetComponent<MoveScript>();
    }

   /* public int GetWeaponPos()
    {
        return weaponPos;
    }

    public GameObject getCurrentWeapon()
    {
        return currentWeapon;
    }

    public void SetCurrentWeapon(GameObject newWep)
    {
        currentWeapon.SetActive(false);
        currentWeapon = newWep;
        currentWeapon.SetActive(true);
    }

    public void SetCurrentProjectile(GameObject proj)
    {
        projectilePrefab = proj;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }*/

    public void Shoot()
    {
        firePoint = new Vector2(GameObject.FindWithTag("Weapon").transform.position.x, GameObject.FindWithTag("Player").transform.position.y + fireOffset);
        
        CreateProjectile(projectilePrefab);
    }

    

    private void CreateProjectile(GameObject projectilePrefab)
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(projectilePrefab, firePoint, transform.rotation);
            
            bullet.GetComponent<LaserScript>().Bullet(mover.facingRight);
        }
        
        
    }

    
}
