using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class StartGame : MonoBehaviour
{
    public string userName;
    bool fileExist;

    public Animator transition;
    public float transitionTime = 1f;

    GameObject fadeInAnimation;

    //LevelLoader loadLevel = new LevelLoader();


    void Start()
    {
        //============ForFileSystem=============================
        /*        if (!fileExist)
                {
                    File.Create("Akrima.txt");
                    fileExist = true;
                }*/
        //============ForFileSystem=============================
        fadeInAnimation = GameObject.Find("CrossFader");
        fadeInAnimation.SetActive(false);
        //GameObject.Find("CrossFader").SetActive(false);

    }
    


    public void LoginButtonFunctionality(InputField ip)
    {
        userName = ip.text;
        //Debug.Log(userName);

        //============ForFileSystem=============================
        //File.WriteAllText("Akrima.txt", userName);
        //============ForFileSystem=============================

        //==========DontDestroyOnLoad===========================
        //----------Deactivate AdditiveScene First--------------
        //DontDestroyOnLoad(GameObject.Find("ScriptToTransfer"));
        //==========DontDestroyOnLoad===========================
        LoadNextLevel();
        //SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    public void LoadNextLevel()
    {
        
        //transition.SetTrigger("Start");
        //transition.Play("End");

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation        
        fadeInAnimation.SetActive(true);
        transition.Play("End");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //transition.SetBool("End", true);
        

        //Load Scene
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Additive);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
