using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    GameObject cylinder;
    [SerializeField] ParticleSystem bigExplosion;
    public AudioClip explosionAudio;
    AudioSource audioSource;
    ParticleSystem particle;
    int bulletCounterForExplosion = 0;

    // Start is called before the first frame update
    void Start()
    {
        cylinder = GameObject.Find("Environment/Cylinders");
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = explosionAudio;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Bullet")
        {
            bulletCounterForExplosion++;
            if(bulletCounterForExplosion > 2)
            {
                //Debug.Log("Collission");
                particle = Instantiate(bigExplosion);
                particle.gameObject.transform.SetParent(cylinder.transform);
                particle.gameObject.transform.position = transform.position;
                particle.Play();

                audioSource.Play();

                gameObject.transform.position = new Vector3(1000f, 1000f, 1000f);

                StartCoroutine(DestroyCylinder());
            }
        }
    }
    IEnumerator DestroyCylinder()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Destroy(particle.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
