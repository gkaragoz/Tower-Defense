using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject levelSelect;

    public Button btn_LevelSelect;
    public Button btn_BackMainMenu;

    public Button btn_Level01;

	void Start () {
        DontDestroyOnLoad(gameObject);
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
