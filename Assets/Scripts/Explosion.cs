using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    GameObject gasTankWhite;
    GameObject cylinder;
    [SerializeField] ParticleSystem bigExplosion;
    [SerializeField] ParticleSystem energyExplosion;

    // Start is called before the first frame update
    void Start()
    {
        cylinder = GameObject.Find("Environment/Cylinders");
        gasTankWhite = GameObject.Find("Environment/Cylinders/Gas Tank Black");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Bullet")
        {
            //Debug.Log("Collission");
            var particle = Instantiate(bigExplosion);
            particle.gameObject.transform.SetParent(cylinder.transform);
            particle.gameObject.transform.position = gasTankWhite.transform.position;
            particle.Play();

            var particle2 = Instantiate(energyExplosion);
            particle2.gameObject.transform.SetParent(cylinder.transform);
            particle2.gameObject.transform.position = gasTankWhite.transform.position;
            particle2.Play();
            StartCoroutine(DestroyCylinder());
            Destroy(gameObject);

        }
    }
    IEnumerator DestroyCylinder()
    {
        yield return new WaitForSeconds(2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
