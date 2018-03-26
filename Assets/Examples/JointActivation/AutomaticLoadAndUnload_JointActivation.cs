using SceneGroupLoader;
using UnityEngine;
using UnityEngine.Assertions;

public class AutomaticLoadAndUnload_JointActivation : MonoBehaviour {

    public SceneGroupLoader.JointActivation.SceneGroupLoaderComponent Loader;

    public SceneGroup SceneGroup1;

    void Awake()
    {
        Assert.IsNotNull(Loader);
        Assert.IsNotNull(SceneGroup1);
    }

	void Start()
    {
        Loader.LoadAndActivateSceneGroup(SceneGroup1, OnSceneGroup1LoadedAndActivated);
	}

    private void OnSceneGroup1LoadedAndActivated(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Loader.UnloadSceneGroup(sceneGroupHandle, OnSceneGroup1Unloaded);
    }

    private void OnSceneGroup1Unloaded(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        Debug.Log("Done");
        Loader.LoadAndActivateSceneGroup(SceneGroup1, OnSceneGroup1LoadedAndActivated);
    }
}
