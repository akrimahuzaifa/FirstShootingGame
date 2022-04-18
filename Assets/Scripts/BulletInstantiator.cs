using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiator : MonoBehaviour
{
    public GameObject BulletPrefab;
    public static GameObject bulletHolder;
    public static List<GameObject> bulletsList = new List<GameObject>();

    private void OnEnable()
    {
        Gun.BulletEvent += InstantiateAndDestroyBullets;
    }
    private void OnDisable()
    {
        Gun.BulletEvent -= InstantiateAndDestroyBullets;
    }


    void InstantiateAndDestroyBullets()
    {
        bulletsList.Add(Instantiate(BulletPrefab, transform.position, transform.rotation));
        //bulletHolder = Instantiate(BulletPrefab, transform.position, transform.rotation);
        //Destroy(bulletHolder, 0.1f);
    }
}
