using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameMenu;

    [SerializeField]
    private GameObject RulePanel;
    [SerializeField]
    //[HideInInspector]
    public bool isGameMenu = false;

    void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    public void GameExit(){
        Application.Quit();
    }

    void ShowGameRule(){
        RulePanel.SetActive(true);    
    }

    public void ExitRule(){
        RulePanel.SetActive(false);
    }

    public void ShowRule(){
        ShowGameRule();
    }

    public void PlayGame(){
        isGameMenu = true;
        gameMenu.SetActive(false);
        Spawner spawn = FindObjectOfType<Spawner>();
        spawn.StartEnemyRoutine();
    }
}
