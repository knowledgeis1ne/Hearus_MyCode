using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance; // 싱글톤 패턴을 위한 정적 인스턴스 필드

    [SerializeField] RectTransform fader;
    [SerializeField] RectTransform fader2;

    public static Action target;
    public static Action target2;

    [Header("Menu Screens")]
    [SerializeField] public GameObject loadingScreen;
    [SerializeField] public GameObject ScreenCanvas;

    [Header("Slider")]
    [SerializeField] public Slider loadingSlider;

    private bool startLoading = false;
    private bool isLoadingComplete = false;

    private void Start()
    {
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 1, 0);
        LeanTween.alpha(fader, 0, 0.5f).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    public void MoveToGame()
    {
        fader2.gameObject.SetActive(true);
        ScreenCanvas.SetActive(false);
        loadingScreen.SetActive(true);

        LeanTween.scale(fader2, Vector3.zero, 0f);
        LeanTween.scale(fader2, new Vector3(1, 1, 1), 2f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            Invoke("LoadGame", 0.5f);
        });

        //StartCoroutine(LoadAsync());
        startLoading = true;  // Set the flag to start loading
    }

    private void LoadGame()
    {
        StartCoroutine(LoadAsync());
        //SceneManager.LoadScene(1);
    }

    public void MoveToFirst()
    {
        fader.gameObject.SetActive(false);
        fader2.gameObject.SetActive(true);

        fader2.localScale = Vector3.zero; // 이 줄 추가

        LeanTween.scale(fader2, Vector3.zero, 0f);
        LeanTween.scale(fader2, new Vector3(1, 1, 1), 2.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            Invoke("LoadFirst", 0.5f);
        });
    }

    private void LoadFirst()
    {
        SceneManager.LoadScene(0);
    }
    
    private void Awake()
    {
        target = () => { MoveToGame(); };
        target2 = () => { MoveToFirst(); };
    }

    private void FixedUpdate()
    {
        if (startLoading && !isLoadingComplete)
        {
            StartCoroutine(LoadAsync());
            startLoading = false;  // Reset the flag to prevent unnecessary loading
        }
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(1);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;

            if (progressValue >= 1f)
            {
                isLoadingComplete = true;
            }

            yield return null;
        }
    }
}
