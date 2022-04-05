using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveForward : MonoBehaviour
{
    public float bulletSpeed = 20f;

    public static Vector3 hitPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        transform.position = Vector3.MoveTowards(transform.position, hitPosition, bulletSpeed * Time.deltaTime);
       // transform.Translate(Vector3.forward * 10f * Time.deltaTime);
    }
}
