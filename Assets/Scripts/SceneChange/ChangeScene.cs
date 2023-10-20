using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Video;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance; // 싱글톤 패턴을 위한 정적 인스턴스 필드
    public int nowmap = 2;

    [SerializeField] RectTransform fader;
    [SerializeField] RectTransform fader2;
    [SerializeField] RectTransform fader3;

    public static Action target;
    public static Action target2;
    public static Action target3;
    public static Action target4;

    [Header("Menu Screens")]
    [SerializeField] public GameObject loadingScreen;
    [SerializeField] public GameObject ScreenCanvas;

    [Header("Slider")]
    [SerializeField] public Slider loadingSlider;

    private bool startLoading = false;
    private bool isLoadingComplete = false;

    //인트로 관련 변수
    public GameObject videoPlayer;

    public void Start()
    {
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 1, 0);
        LeanTween.alpha(fader, 0, 0.5f).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    private void Awake()
    {
        target = () => { MoveToGame(); };
        target2 = () => { MoveToFirst(); };
        target3 = () => { MoveToIntro();};
        target4 = () => { MoveToAnotherMap();};
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

        startLoading = true;
    }

    private void LoadGame()
    {
        StartCoroutine(LoadAsync());
    }

    public void MoveToFirst()
    {
        fader.gameObject.SetActive(false);
        fader2.gameObject.SetActive(true);

        fader2.localScale = Vector3.zero;

        LeanTween.scale(fader2, Vector3.zero, 0f);
        LeanTween.scale(fader2, new Vector3(1, 1, 1), 2.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            Invoke("LoadFirst", 0.5f);
        });
    }

    private void LoadFirst()
    {
                Debug.Log("LoadFirst 호출");

        SceneManager.LoadScene(0);
    }

    // private void FixedUpdate()
    // {
    //     Debug.Log("FixedUpdate 호출");

    //     if (startLoading && !isLoadingComplete)
    //     {
    //         StartCoroutine(LoadAsync());
    //         startLoading = false;
    //     }
    // }

    public void Map(int map)
    {
        nowmap = map;
        target();
    }

    IEnumerator LoadAsync()
    {
                                Debug.Log("LoadAsync 호출");

        if (DataManager.instance.nowPlayer.currentMap.Equals("태초의숲"))
        {
            nowmap = 2;
        }
        else if (DataManager.instance.nowPlayer.currentMap.Equals("비탄의바다"))
        {
            nowmap = 3;
        }
        else if (DataManager.instance.nowPlayer.currentMap.Equals("타오르는황야"))
        {
            nowmap = 4;
        }
        
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nowmap);

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

    public void MoveToIntro()
    {
                        Debug.Log("MoveToIntro 호출");

        if(videoPlayer != null)
        {
            videoPlayer.gameObject.SetActive(false);
        }
        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 1f).setOnComplete(() =>
        {
            Invoke("LoadIntro", 0.5f);
        });
    }

    private void LoadIntro()
    {
                Debug.Log("LoadIntro 호출");

        //DataManager.instance.nowPlayer.firstStart = false;
        //DataManager.instance.SaveData(DataManager.instance.nowSlot);
        SceneManager.LoadScene(1);
    }

    public void MoveToAnotherMap()
    {
        Debug.Log("MoveToAnotherMap 호출");

        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 1f).setOnComplete(() =>
        {
            Invoke("LoadAnotherMap", 1f);
            //fader.gameObject.SetActive(false);
        });

        if (DataManager.instance.nowPlayer.currentMap.Equals("태초의숲"))
        {
            nowmap = 2;
        }
        else if (DataManager.instance.nowPlayer.currentMap.Equals("비탄의바다"))
        {
            nowmap = 3;
        }
        else if (DataManager.instance.nowPlayer.currentMap.Equals("타오르는황야"))
        {
            nowmap = 4;
        }
        //SceneManager.LoadScene(nowmap);
    }

    private void LoadAnotherMap()
    {
        Debug.Log("LoadAnotherMap호출 현재 이 맵으로 이동2 ---> " + nowmap);
        SceneManager.LoadScene(nowmap);
    }
}