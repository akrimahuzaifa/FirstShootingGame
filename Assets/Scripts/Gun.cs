using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public GameObject bullet;
    GameObject bulletsHolder;
    public static GameObject go;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public float nextTimeToFire = 0f;

    int magzine = 60;


    List<GameObject> flareEffectList = new List<GameObject>();

    public static event MyDlegates.PlayGunSoundsDelegate PlayGunShotEvent;
    public static event MyDlegates.UIDelegate UIEvent;
    public static event MyDlegates.BulletHandlerDelegate BulletEvent;

    private void Start()
    {
        bulletsHolder = GameObject.Find("BulletsHolder");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time * 1f / fireRate;
            Shoot();
            //ShootInAir();
            //Debug.Log("Holding button down");
        }

        Reload();
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || magzine <= 0)
        {
            magzine = 60;
        }
        UIEvent?.Invoke(magzine);
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.DrawRay(Camera.main.transform.position, hit.point, Color.red);
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (magzine > 0)
            {
                PlayGunShotEvent?.Invoke();

                /*GameObject gameObjectDeleteBullet = Instantiate(bullet, transform.position, transform.rotation);
                Destroy(gameObjectDeleteBullet, 2f);*/

                BulletEvent?.Invoke();

                muzzleFlash.Play();
                magzine--;

                //go.transform.SetParent(bulletsHolder.transform);

                BulletMoveForward.hitPosition = hit.point;

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                //==============FlareEffect==============================
                //===========Using Lists=================================
                flareEffectList.Add(Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)));
                foreach (GameObject flareEffect in flareEffectList)
                {
                    Destroy(flareEffect, 2f);
                }
                //===========Using Lists=================================
                //GameObject gameObjectDeleteEffect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                //Destroy(gameObjectDeleteEffect, 2f);
                //==============FlareEffect==============================
            }
        }
    }

    void ShootInAir()
    {
        if (magzine > 0)
        {
            PlayGunShotEvent?.Invoke();
            BulletEvent?.Invoke();
            muzzleFlash.Play();
            magzine--;
        }
    }
}
