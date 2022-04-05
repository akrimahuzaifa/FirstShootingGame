using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip gunShot;
    public AudioClip bulletCover;
    AudioSource sourceClip;

    
    private void OnEnable()
    {
        Gun.PlayGunShotEvent += GunShotPlay;
        
        Gun.PlayGunShotEvent += BulletDrop;
    }

    private void OnDisable()
    {
        Gun.PlayGunShotEvent -= GunShotPlay;
        Gun.PlayGunShotEvent -= BulletDrop;
    }

    void GunShotPlay()
    {
        //Debug.Log("gunfire");
        sourceClip.clip = gunShot;
        sourceClip.Play();
       
    }
    void BulletDrop()
    {
        StartCoroutine(WaitForShot());
    
    }

     IEnumerator WaitForShot()
    {
        float sec = sourceClip.clip.length;
        //Debug.Log("Adeel: " + sec);
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("bulletDesire");
        sourceClip.clip = bulletCover;
        sourceClip.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        sourceClip = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
