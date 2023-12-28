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
        DontDestroyOnLoad(this.gameObject); /// sahneler yenilendiðinde her þey baþtan yaratýlýyor, ama bu fonksiyon yeniden yeniden yaratma diye yazýyoruz. bunu hiçbir zaman yok etme diyoruz, destroy etme.
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
        currentLevel = PlayerPrefs.GetInt("levelKey", 1); // mevcut olan içindeki kaydettiðimiz veriyi almamýzý ve o veriyi tekrardan eklememize yarýyan metod PlayerPrefs.GetInt metodu.
        // telefondan uygulamayý silene kadar verimizi saklýyor.
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
