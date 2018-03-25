using SceneGroupLoader;
using UnityEngine;
using UnityEngine.Assertions;

public class AutomaticLoadAndUnload_SeparateActivation : MonoBehaviour {

    public SceneGroupLoader.SeparateActivation.SceneGroupLoaderComponent Loader;

    public SceneGroup SceneGroup1;

    void Awake()
    {
        Assert.IsNotNull(Loader);
        Assert.IsNotNull(SceneGroup1);
    }

	void Start()
    {
        Loader.LoadSceneGroup(SceneGroup1, OnSceneGroup1Loaded);
	}

    private void OnSceneGroup1Loaded(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Loader.ActivateSceneGroup(sceneGroupHandle, OnSceneGroup1Activated);
    }

    private void OnSceneGroup1Activated(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Loader.UnloadSceneGroup(sceneGroupHandle, OnSceneGroup1Unloaded);
    }

    private void OnSceneGroup1Unloaded(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Debug.Log("Done");
        Loader.LoadSceneGroup(SceneGroup1, OnSceneGroup1Loaded);
    }
}
