using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveForward : MonoBehaviour
{
    public float bulletSpeed = 100f;
    public static Vector3 hitPosition;
    
 
    void Update()
    {  
        transform.position = Vector3.MoveTowards(transform.position, hitPosition, bulletSpeed * Time.deltaTime);
        // transform.Translate(Vector3.forward * 10f * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("hitting bullet");
            Destroy(collision.collider.gameObject);
        }
        //Debug.Log("BulletHolder: " + BulletInstantiator.bulletsList.Count);
        foreach(GameObject go in BulletInstantiator.bulletsList)
        {
            Destroy(go);
        }
        BulletInstantiator.bulletsList.Clear();
    }
}
