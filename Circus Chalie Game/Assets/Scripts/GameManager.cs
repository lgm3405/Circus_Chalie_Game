using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public bool isGrounded = false;
    public bool isDead = false;
    public bool max_loop = false;
    public bool wall = false;
    public int loop_count = 0;

    private void Awake()
    {
        if (instance.isValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isGameOver == true && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        //gameoverUi.SetActive(true);
    }
}
