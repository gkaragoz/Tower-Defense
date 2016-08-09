using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private GameObject mainMenu;
    private GameObject levelSelect;

    private Button btn_LevelSelect;
    private Button btn_BackMainMenu;

    private Button btn_Level01;

	void Start () {
        DontDestroyOnLoad(gameObject);

        mainMenu = GameObject.Find("Canvas/Panel/MainMenu");
        levelSelect = GameObject.Find("Canvas/Panel/LevelSelect");

        btn_LevelSelect = mainMenu.transform.Find("btn_LevelSelect").GetComponent<Button>();
        btn_BackMainMenu = levelSelect.transform.Find("btn_BackMainMenu").GetComponent<Button>();
        btn_Level01 = levelSelect.transform.Find("btn_Level01").GetComponent<Button>();

        btn_LevelSelect.onClick.AddListener(delegate
        {
            OpenLevelSelectMenu();
        });
        btn_BackMainMenu.onClick.AddListener(delegate
        {
            BackToMainMenu(btn_BackMainMenu.transform.parent.gameObject);
        });
        btn_Level01.onClick.AddListener(delegate
        {
            SelectLevel(1);
        });

        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }
	
    void OpenLevelSelectMenu()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    void BackToMainMenu(GameObject currentMenu)
    {
        currentMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    void SelectLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
