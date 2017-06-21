using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{ 
    public static void SetActive( string name)
    {
        var scene = SceneManager.GetSceneByName(name);
        if (scene.isLoaded)
        {

            SceneManager.SetActiveScene(scene);

        }

    }

    /// <summary>
    /// シーンの上書き
    /// </summary>
    /// <param name="name"></param>
    public static void Replace( string name)
    {

        SceneManager.LoadScene(name, LoadSceneMode.Single);

    }

    /// <summary>
    /// シーンの追加
    /// </summary>
    /// <param name="name"></param>
    public static void Add( string name)
    {

        if ( !SceneManager.GetSceneByName( name ).isLoaded)
        {

            SceneManager.LoadScene( name , LoadSceneMode.Additive );
        }

    }

    /// <summary>
    /// 削除
    /// </summary>
    /// <param name="name"></param>
    public static void Remove( string name )
    {
        if (SceneManager.GetSceneByName(name).isLoaded)
        {

            SceneManager.UnloadSceneAsync(name);

        }

    }

    /// <summary>
    /// オブジェクトのシーン間移動
    /// </summary>
    /// <param name="name"></param>
    public static void MoveGameObject(GameObject obj , string name)
    {
        var scene = SceneManager.GetSceneByName(name);
        if (scene.isLoaded && !obj.scene.name.Equals( name) ) {

            SceneManager.MoveGameObjectToScene(obj,scene);

        }

    }


}
