using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return instance; }
        set { _instance = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
                SceneManager.LoadScene("MainMenu");
            else
                SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Quit();
        }
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void GoToEndScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
