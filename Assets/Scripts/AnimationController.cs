using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    GameObject objAnimator;
    public Animator animation;

    private void Awake()
    {
        objAnimator = GameObject.Find("CrossFader");
        animation.Play("Start");
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisablePanel", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisablePanel()
    {
        objAnimator.SetActive(false);
    }
}
