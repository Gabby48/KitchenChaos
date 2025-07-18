using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Loader;

public static class Loader
{
 
    public enum Scene
    {
        MainMenu,
        GameScene,
        LoadingScreen
    }
    private static Scene targetScene;
    private static Scene selectedScene;

    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());


    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
        
       
       
    }

    public static void Unload(Scene scene)
    {
        SceneManager.UnloadSceneAsync(scene.ToString());
    }

    

}
