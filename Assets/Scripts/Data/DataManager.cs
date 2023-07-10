using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    public string filename;
    public int item;

    //플레이어 위치
    public float x = 27f;
    public float y = 31f;
    public float z = -73f;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // 싱글톤패턴

    public PlayerData nowPlayer = new PlayerData(); // 플레이어 데이터 생성
    public PlayerData nowPlayerDefault = new PlayerData(); // 기본 플레이어 데이터 생성

    public string path; // 경로
    public int nowSlot; // 현재 슬롯번호


    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        // 기본 플레이어 위치 설정
        nowPlayerDefault.x = 27f;
        nowPlayerDefault.y = 31f;
        nowPlayerDefault.z = -73f;

        path = Application.persistentDataPath + "/save";	// 경로 지정
        print(path);
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}