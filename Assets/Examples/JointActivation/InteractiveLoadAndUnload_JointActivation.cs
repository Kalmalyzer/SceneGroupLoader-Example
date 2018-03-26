using System;
using SceneGroupLoader;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class InteractiveLoadAndUnload_JointActivation : MonoBehaviour {

    public SceneGroupLoader.JointActivation.SceneGroupLoaderComponent Loader;

    public Button LoadSceneGroup1;
    public Button UnloadSceneGroup1;
    public Button LoadSceneGroup2;
    public Button UnloadSceneGroup2;
    public Button Switch1To2;
    public Button Switch2To1;

    public SceneGroupLoader.SceneGroup SceneGroup1;
    public SceneGroupLoader.SceneGroup SceneGroup2;

    private SceneGroupLoader.SceneGroupHandle loadedSceneGroup1;
    private SceneGroupLoader.SceneGroupHandle loadedSceneGroup2;

    void Awake()
    {
        Assert.IsNotNull(Loader);

        Assert.IsNotNull(LoadSceneGroup1);
        Assert.IsNotNull(UnloadSceneGroup1);
        Assert.IsNotNull(LoadSceneGroup2);
        Assert.IsNotNull(UnloadSceneGroup2);
        Assert.IsNotNull(Switch1To2);
        Assert.IsNotNull(Switch2To1);

        Assert.IsNotNull(SceneGroup1);
        Assert.IsNotNull(SceneGroup2);
    }

    void Start()
    {
        ReactivateButtons();
    }

    ///////////////////// SceneGroup1 related buttons ////////////////////

    public void OnLoadSceneGroup1()
    {
        DeactivateButtons();
        Loader.LoadAndActivateSceneGroup(SceneGroup1, OnLoadAndActivateSceneGroup1Done);
    }

    private void OnLoadAndActivateSceneGroup1Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup1 = sceneGroupHandle;
        ReactivateButtons();
    }

    public void OnUnloadSceneGroup1()
    {
        DeactivateButtons();
        Loader.UnloadSceneGroup(loadedSceneGroup1, OnUnloadSceneGroup1Done);
    }

    private void OnUnloadSceneGroup1Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup1 = null;
        ReactivateButtons();
    }

    ///////////////////// SceneGroup2 related buttons ////////////////////

    public void OnLoadSceneGroup2()
    {
        DeactivateButtons();
        Loader.LoadAndActivateSceneGroup(SceneGroup2, OnLoadAndActivateSceneGroup2Done);
    }

    private void OnLoadAndActivateSceneGroup2Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup2 = sceneGroupHandle;
        ReactivateButtons();
    }

    public void OnUnloadSceneGroup2()
    {
        DeactivateButtons();
        Loader.UnloadSceneGroup(loadedSceneGroup2, OnUnloadSceneGroup2Done);
    }

    private void OnUnloadSceneGroup2Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup2 = null;
        ReactivateButtons();
    }

    ///////////////////// Switch related buttons ////////////////////

    public void OnSwitch1To2()
    {
        DeactivateButtons();
        Loader.UnloadSceneGroup(loadedSceneGroup1, OnSwitchUnload1Done);
    }

    private void OnSwitchUnload1Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup1 = null;
        Loader.LoadAndActivateSceneGroup(SceneGroup2, OnSwitchLoadAndActivate2Done);
    }

    private void OnSwitchLoadAndActivate2Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup2 = sceneGroupHandle;
        ReactivateButtons();
    }

    public void OnSwitch2To1()
    {
        DeactivateButtons();
        Loader.LoadAndActivateSceneGroup(SceneGroup1, OnSwitchLoadAndActivate1Done);
    }

    private void OnSwitchLoadAndActivate1Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup1 = sceneGroupHandle;
        Loader.UnloadSceneGroup(loadedSceneGroup2, OnSwitchUnload2Done);
    }

    private void OnSwitchUnload2Done(SceneGroupLoader.SceneGroupHandle sceneGroupHandle)
    {
        loadedSceneGroup2 = null;
        ReactivateButtons();
    }

    ///////////////////// Shared functionality ////////////////////

    private void DeactivateButtons()
    {
        LoadSceneGroup1.interactable = false;
        UnloadSceneGroup1.interactable = false;
        LoadSceneGroup2.interactable = false;
        UnloadSceneGroup2.interactable = false;
        Switch1To2.interactable = false;
        Switch2To1.interactable = false;
    }

    private void ReactivateButtons()
    {
        LoadSceneGroup1.interactable = (loadedSceneGroup1 == null);
        UnloadSceneGroup1.interactable = (loadedSceneGroup1 != null);
        LoadSceneGroup2.interactable = (loadedSceneGroup2 == null);
        UnloadSceneGroup2.interactable = (loadedSceneGroup2 != null);
        Switch1To2.interactable = (loadedSceneGroup1 != null && loadedSceneGroup2 == null);
        Switch2To1.interactable = (loadedSceneGroup1 == null && loadedSceneGroup2 != null);
    }
}
