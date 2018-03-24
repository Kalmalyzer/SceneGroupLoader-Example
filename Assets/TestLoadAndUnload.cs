using System;
using SceneGroupLoader;
using UnityEngine;
using UnityEngine.Assertions;

public class TestLoadAndUnload : MonoBehaviour {

    public SceneGroupLoaderComponent Loader;

    public SceneGroup SceneGroup1;

    void Awake()
    {
        Assert.IsNotNull(Loader);
        Assert.IsNotNull(SceneGroup1);
    }

	// Use this for initialization
	void Start () {

        Loader.LoadSceneGroup(SceneGroup1, OnSceneGroup1Loaded);
	}

    private void OnSceneGroup1Loaded(SceneGroupLoader.SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Loader.ActivateSceneGroup(sceneGroupHandle, OnSceneGroup1Activated);
    }

    private void OnSceneGroup1Activated(SceneGroupLoader.SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Loader.UnloadSceneGroup(sceneGroupHandle, OnSceneGroup1Unloaded);
    }

    private void OnSceneGroup1Unloaded(SceneGroupLoader.SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Debug.Log("Done");
    }
}
