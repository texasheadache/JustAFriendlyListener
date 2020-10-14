using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelLoader2 : MonoBehaviour
{

    [SerializeField] private Text progressText;
    [SerializeField] private Slider slider;
    //public loadNewArea loadNewArea;
    public string levelToLoad;

    private AsyncOperation operation;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>(true);
        DontDestroyOnLoad(gameObject);
        loadNewArea loadNewArea = gameObject.GetComponent<loadNewArea>();
        levelToLoad = loadNewArea.levelToLoad;
    }

    public void LoadScene(string levelToLoad)
    {
        UpdateProgressUI(0);
        canvas.gameObject.SetActive(true);

        StartCoroutine(BeginLoad(levelToLoad));
    }

    private IEnumerator BeginLoad(string levelToLoad)
    {
        operation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return null;
        }

        UpdateProgressUI(operation.progress);
        operation = null;
        canvas.gameObject.SetActive(false);
    }

    private void UpdateProgressUI(float progress)
    {
        slider.value = progress;
        progressText.text = (int)(progress * 100f) + "%";
    }

}