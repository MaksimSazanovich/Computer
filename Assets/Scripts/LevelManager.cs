using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int sceneIndex;
    [SerializeField] private CameraMove cameraMove;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && cameraMove.IsStartPosition() && sceneIndex == 1)
        {
            LoadMenu();
        }
    }
}
