using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;
using Unity.EditorCoroutines.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class LevelWindow : EditorWindow
{
    private Vector2 scrollPosition;
    private string searchFilter = "";

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Level Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(LevelWindow));
    }

    private void OnEnable()
    {
        titleContent.text = "Level Window";
    }

    void OnGUI()
    {
        // --- UI Styles ---
        GUILayout.Label("Scenes", EditorStyles.boldLabel);
        GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
        boxStyle.stretchWidth = true;

        GUIStyle mainButtonStyle = new GUIStyle(GUI.skin.button);
        GUIStyle subButtonStyle = new GUIStyle(GUI.skin.button);
        GUIStyle completeButtonStyle = new GUIStyle(GUI.skin.button);

        mainButtonStyle.fontStyle = FontStyle.Bold;
        mainButtonStyle.normal.textColor = Color.blue;

        completeButtonStyle.normal.textColor = new Color(0, 0.4f, 0f);
        completeButtonStyle.fontStyle = FontStyle.Bold;

        // --- Variables ---
        bool isMainScene = false;
        bool mainChunkOpen = false;
        bool searchFilterActive = false;
        List<string> mainSceneInclSubscenes = new List<string>();

        // --- TextView ---
        EditorGUILayout.BeginHorizontal();
        searchFilter = EditorGUILayout.TextField(searchFilter);
        searchFilter = searchFilter.Trim();

        if(GUILayout.Button("X"))
            searchFilter = "";

        EditorGUILayout.EndVertical();
        searchFilterActive = !string.IsNullOrEmpty(searchFilter);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true, GUILayout.ExpandWidth(true));

        foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            string path = scene.path;
            string fileName = Path.GetFileName(path);

            if(fileName.Contains("Shell_Load") || fileName.Contains("Shell_End"))
                continue;

            // --- Draw BoxLayout ---
            isMainScene = fileName.Contains("Chunked");
            bool isSubScene = fileName.Contains("Chunk_");
            bool singleScene = (isMainScene || !isMainScene && !isSubScene);

            if(mainChunkOpen && singleScene)
            {
                if(GUILayout.Button("Load all Scenes", completeButtonStyle))
                    EditorCoroutineUtility.StartCoroutine(OpenScenesAsync(mainSceneInclSubscenes.ToArray()), this);

                mainChunkOpen = false;
                EditorGUILayout.EndVertical();
            }
            else if(mainChunkOpen && !isSubScene)
            {
                EditorGUILayout.EndVertical();
                mainChunkOpen = false;
            }

            if(searchFilterActive && !fileName.Contains(searchFilter))
                continue;

            if(isMainScene)
            {
                EditorGUILayout.BeginVertical(boxStyle, GUILayout.ExpandWidth(true));
                mainChunkOpen = true;
                mainSceneInclSubscenes.Clear();
                mainSceneInclSubscenes.Add(path);
            }
            else if(mainChunkOpen)
            {
                mainSceneInclSubscenes.Add(path);
            }

            // --- Draw Buttons ---
            if(GUILayout.Button(fileName, singleScene ? mainButtonStyle : subButtonStyle))
                EditorCoroutineUtility.StartCoroutine(OpenSceneAsync(scene.path, singleScene ? OpenSceneMode.Single : OpenSceneMode.Additive), this);
        }

        GUILayout.EndScrollView();
    }

    #region Utilities

    private void OpenScene(string scene, OpenSceneMode sceneMode)
    {
        string _fileName = Path.GetFileName(scene);
        EditorSceneManager.OpenScene(scene, sceneMode);
    }

    private void OpenScenes(string[] scenes)
    {
        foreach(string scenePath in scenes)
        {
            string _fileName = Path.GetFileName(scenePath);
            OpenScene(scenePath, _fileName.Contains("Chunked") ? OpenSceneMode.Single : OpenSceneMode.Additive);
        }
    }

    private IEnumerator OpenSceneAsync(string scene, OpenSceneMode sceneMode)
    {
        yield return new WaitForEndOfFrame();
        string _fileName = Path.GetFileName(scene);
        OpenScene(scene, sceneMode);
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator OpenScenesAsync(string[] scenes)
    {
        yield return new WaitForEndOfFrame();

        foreach(string scenePath in scenes)
        {
            string _fileName = Path.GetFileName(scenePath);
            OpenScene(scenePath, _fileName.Contains("Chunked") ? OpenSceneMode.Single : OpenSceneMode.Additive);
            yield return new WaitForEndOfFrame();
        }
    }

    #endregion
}

