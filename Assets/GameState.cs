using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    int _sceneNum = 0;
    bool farmComplete = false;
    bool eduSuccess = false;

    public static GameState Instance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire3") && SceneManager.GetActiveScene().buildIndex == 0){
            MenuStart();
        }
        else if(Input.GetButtonDown("Fire3") && SceneManager.GetActiveScene().buildIndex == 2){
            MenuEnd();
        }
    }

    public void MenuStart()
    {
        _sceneNum = _sceneNum + 1;
        SceneManager.LoadScene(_sceneNum, LoadSceneMode.Single);
    }

    public void MenuEnd()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2){
            _sceneNum = 0;
            SceneManager.LoadScene(_sceneNum, LoadSceneMode.Single);
            Destroy(gameObject);
        }
    }

    public void CompleteFarm()
    {
        farmComplete = true;
    }

    public bool IsComplete()
    {
        return farmComplete;
    }

    public void CompleteEducation()
    {
        eduSuccess = true;
    }

    public bool SuccessfulEducation()
    {
        return eduSuccess;
    }

}

