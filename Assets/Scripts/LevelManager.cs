using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Material[] skyMaterial;
    public GameObject[] skins;
    int currentMaterialIndex = 0;
    public int currentSkinIndex = 0;
    [SerializeField] float timer = 0;
    public int score = 0;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] GameObject endScreen;


    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skyMaterial[0];
        currentSkinIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SkyBoxChanger();
        SkinChanger();
        GameOver();

    }

    public void ChangeSkyBox()
    {
        currentMaterialIndex += 1;
    }

    void SkyBoxChanger()
    {
        if (currentMaterialIndex == 0)
        {
            RenderSettings.skybox = skyMaterial[0];
            SkyBoxRotation();
        }
        else if (currentMaterialIndex == 1)
        {
            RenderSettings.skybox = skyMaterial[1];
            SkyBoxRotation();
        }
        else if (currentMaterialIndex == 2)
        {
            RenderSettings.skybox = skyMaterial[2];
            SkyBoxRotation();
        }

        if (currentMaterialIndex > 2)
        {
            currentMaterialIndex = 0;
        }
    }

    void SkyBoxRotation()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 4);
    }

    public void ChangeSkin()
    {
        currentSkinIndex += 1;


    }

    void SkinChanger()
    {
        if (currentSkinIndex == 0)
        {
            skins[0].SetActive(true);
            skins[1].SetActive(false);
        }
        else if (currentSkinIndex == 1)
        {
            skins[0].SetActive(false);
            skins[1].SetActive(true);
        }

        if (currentSkinIndex == 2)
        {
            currentSkinIndex = 0;
        }
    }


    void GameOver()
    {
        if (score < 13)
        {
            endScreen.SetActive(false);
            timer += Time.deltaTime;
        }

        // Check for game over condition
        if (score == 13)
        {
            endScreen.SetActive(true);
            time.SetText(Mathf.FloorToInt(timer) + " Seconds!");
        }

    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }


}
