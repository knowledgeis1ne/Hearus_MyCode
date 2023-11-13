using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using Unity.VisualScripting;

public class Ending : MonoBehaviour
{
    public GameObject fader;
    public ScriptManager scriptManager;
    public int frithInfo = 0;
    public int repairCount = 0;
    public int repair = 0;

    private void Start()
    {
        if (DataManager.instance.nowPlayer.gameEnding)
        {
            StartCoroutine("FadeOutScene");

            if (DataManager.instance.nowPlayer.endingName == "ending_332")
            {
                // 엔딩 영상 재생
            }
            else
            {
                scriptManager.FindScriptByEventName(DataManager.instance.nowPlayer.endingName);
                scriptManager.ShowScript();
            }
        }
    }

    public void MoveToMain() // 스크립트 매니저에서 스크립트가 끝나면 Invoke => 호출
    {
        if (scriptManager.currentScript.eventName.Contains("ending"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Count()
    {
        // 프리스 정보 개수
        if (DataManager.instance.nowPlayer.FrithInfo == 0)
            frithInfo = 0;
        else if (DataManager.instance.nowPlayer.FrithInfo > 0 && DataManager.instance.nowPlayer.FrithInfo < 20)
            frithInfo = 1;
        else if (DataManager.instance.nowPlayer.FrithInfo == 20)
            frithInfo = 2;

        // 모은 부품과 연료 카운트
        for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++)
        {
            if (Inventory.instance.inventoryItemList[i].itemType == Item.ItemType.부품)
                repairCount++;
            else if (Inventory.instance.inventoryItemList[i].itemType == Item.ItemType.연료)
                repairCount++;
        }

        // 연료 5개, 부품 6개
        // 하나 모을 때마다 9%씩 수행도 올라감
        if (repairCount >= 0 && repairCount < 4)
            repair = 0;
        else if (repairCount >= 4 && repairCount < 6)
            repair = 1;
        else if (repairCount >= 6 && repairCount < 8)
            repair = 2;
        else if (repairCount >= 8 && repairCount < 11)
            repair = 3;
        else if (repairCount == 11)
            repair = 4;
    }

    public void GameEnding() // 스크립트 매니저에서 스크립트가 끝나면 Invoke => 호출
    {
        if (scriptManager.currentScript.eventName == "scriptSwitch_10")
        {
            DataManager.instance.nowPlayer.gameEnding = true;
            Time.timeScale = 1;

            Count();

            switch (frithInfo)
            {
                case 0:
                    if (repair == 0)
                        scriptManager.FindScriptByEventName("ending_10");
                    else if (repair == 1)
                        scriptManager.FindScriptByEventName("ending_10");
                    else if (repair == 2)
                        scriptManager.FindScriptByEventName("ending_10");
                    else if (repair == 3)
                        scriptManager.FindScriptByEventName("ending_10");
                    else if (repair == 4)
                        scriptManager.FindScriptByEventName("ending_10");
                    DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
                    StartCoroutine("FadeOutScene");
                    scriptManager.ShowScript();
                    break;
                case 1:
                    if (repair == 0)
                        scriptManager.FindScriptByEventName("ending_20");
                    else if (repair == 1)
                        scriptManager.FindScriptByEventName("ending_21");
                    else if (repair == 2)
                        scriptManager.FindScriptByEventName("ending_22");
                    else if (repair == 3)
                        scriptManager.FindScriptByEventName("ending_23");
                    else if (repair == 4)
                        scriptManager.FindScriptByEventName("ending_24");
                    DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
                    StartCoroutine("FadeOutScene");
                    scriptManager.ShowScript();
                    break;
                case 2:
                    if (repair == 0)
                    {
                        scriptManager.FindScriptByEventName("ending_30");
                        DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
                        StartCoroutine("FadeOutScene");
                        scriptManager.ShowScript();
                    }
                    else if (repair == 1)
                    {
                        scriptManager.FindScriptByEventName("ending_31");
                        DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
                        StartCoroutine("FadeOutScene");
                        scriptManager.ShowScript();
                    }
                    else if (repair == 2)
                    {
                        scriptManager.FindScriptByEventName("ending_32");
                        DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
                        StartCoroutine("FadeOutScene");
                        scriptManager.ShowScript();
                    }
                    else
                    {
                        scriptManager.FindScriptByScriptID(244);
                        scriptManager.ShowOption();
                    }
                    break;
            }
        }
        else
            return;
    }

    public void TakeFrithEnding()
    {
        if (repair == 3)
        {
            scriptManager.FindScriptByEventName("ending_330");
            DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
            StartCoroutine("FadeOutScene");
            scriptManager.ShowScript();
        }
        else if (repair == 4)
        {
            scriptManager.FindScriptByEventName("ending_340");
            DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
            StartCoroutine("FadeOutScene");
            scriptManager.ShowScript();
        }
    }

    public void LeaveFrithEnding()
    {
        if (repair == 3)
        {
            scriptManager.FindScriptByEventName("ending_331");
            DataManager.instance.nowPlayer.endingName = scriptManager.currentScript.eventName;
            StartCoroutine("FadeOutScene");
            scriptManager.ShowScript();
        }
        else if (repair == 4)
        {
            // 오리지널 엔딩 재생
            DataManager.instance.nowPlayer.endingName = "ending_332";
        }
    }

    private IEnumerator FadeOutScene()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);

        if (fader.gameObject.activeSelf == false) // fader가 비활성화되어 있다면 활성화
            fader.SetActive(true);

        Color c = fader.GetComponent<Image>().color;

        for (float f = 0f; f <= 1f; f += 0.025f) // 페이드 아웃
        {
            c.a = f;
            fader.GetComponent<Image>().color = c;
            yield return wait;
        }
    }
}
