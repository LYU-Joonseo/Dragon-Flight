using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]    // 유니티 내에서 수정 가능
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject gameWinPanel;

    // [SerializeField]
    // private GameObject gameMenu;

    private int coin = 0;

    [HideInInspector]   // 유니티 내에서 수정 불가
    public bool isGameOver = false;

    // [HideInInspector]
    // public bool isGameMenu = false;

    void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    public void IncreaseCoin(){
        coin++;
        text.SetText(coin.ToString());

        if(coin % 30 == 0){
            Player player = FindObjectOfType<Player>();
            if(player != null){
                player.Upgrade();
            }
        }
    }

    public void SetGameOver(bool over){
        isGameOver = true;

        Spawner spawner = FindObjectOfType<Spawner>();
        if(spawner != null){
            spawner.StopEnemyRoutine();
        }

        if(over == false){
            Invoke("ShowGameOverPanel", 1f);
        }else{
            Invoke("ShowGameWinPanel", 1f);
        }
    }

    void ShowGameOverPanel(){
        gameOverPanel.SetActive(true);
    }

    void ShowGameWinPanel(){
        gameWinPanel.SetActive(true);
    }

    // void GameMenuPanel(){
    //     gameMenu.SetActive(false);
    // }

    // public void PlayGame(){
    //     isGameMenu = true;
    //     GameMenuPanel();
    // }

    public void PlayAgain(){
        SceneManager.LoadScene("GameScene");
    }
}
