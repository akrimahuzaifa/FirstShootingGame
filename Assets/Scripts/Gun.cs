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

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public float nextTimeToFire = 0f;

    int magzine = 60;

    List<GameObject> bulletsList = new List<GameObject>();
    List<GameObject> flareEffectList = new List<GameObject>();

    public static event MyDlegates.PlayGunSoundsDelegate PlayGunShotEvent;
    public static event MyDlegates.UIDelegate UIEvent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time * 1f / fireRate;
            Shoot();
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
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.DrawRay(Camera.main.transform.position, hit.point, Color.red);
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (magzine > 0)
            {
                PlayGunShotEvent?.Invoke();

                //GameObject gameObjectDeleteBullet = Instantiate(bullet, transform.position, transform.rotation);
                bulletsList.Add(Instantiate(bullet, transform.position, transform.rotation));
                muzzleFlash.Play();
                magzine--;
                //Debug.Log(bulletsList.Count);

                
                foreach (GameObject bullet in bulletsList)
                {
                    Destroy(bullet, 2f);
                }

                StartCoroutine(ClearBulletList());
                IEnumerator ClearBulletList()
                {
                    yield return new WaitForSeconds(2f);
                    bulletsList.Clear();        
                }
                //Debug.Log("After Clear: " + bulletsList.Count);

                //Debug.Log(hit.point);
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
}
