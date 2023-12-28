using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    private int currentLevel;
    private int maxLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        maxLevel = 2;
        DontDestroyOnLoad(this.gameObject); /// sahneler yenilendi�inde her �ey ba�tan yarat�l�yor, ama bu fonksiyon yeniden yeniden yaratma diye yaz�yoruz. bunu hi�bir zaman yok etme diyoruz, destroy etme.
        GetLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLevel()
    {
        currentLevel = PlayerPrefs.GetInt("levelKey", 1); // mevcut olan i�indeki kaydetti�imiz veriyi almam�z� ve o veriyi tekrardan eklememize yar�yan metod PlayerPrefs.GetInt metodu.
        // telefondan uygulamay� silene kadar verimizi sakl�yor.
        LoadLevel();
    }

    public void LoadLevel()
    {
        string LevelName = "LevelScene" + currentLevel.ToString();
        SceneManager.LoadScene(LevelName);
    }

    public void NextLevel()
    {
        currentLevel++;
        if (currentLevel > maxLevel)
        {
            currentLevel = 1;
        }
        PlayerPrefs.SetInt("levelKey", currentLevel);
        LoadLevel();
    }
}
