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
    public bool fire_type_check = false;
    public int loop_count = 0;
    public int fire_type = 0;
    public AudioClip BonusClip;
    public AudioClip HitClip;
    public AudioClip HitMusicClip;
    public Text TimeText;
    public Text ScoreText;
    public GameObject gameoverUi;

    private AudioSource GameAudio = default;
    private float game_time = 0;
    private float check_time = 1f;
    private int second_time = 0;
    private int minute_time = 0;
    private int score = 0;

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
        GameAudio = GetComponent<AudioSource>();
        Debug.Assert(GameAudio != null);
    }

    void Update()
    {
        if (isGameOver == false)
        {
            game_time += Time.deltaTime;
            if (game_time >= check_time)
            {
                second_time += 1;
                if (second_time >= 60)
                {
                    minute_time += 1;
                    second_time = 0;
                }

                game_time = 0;
            }

            TimeText.text = string.Format("Time = {0} : {1}", minute_time, second_time);
        }
        else if (isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        //gameoverUi.SetActive(true);
        GameAudio.clip = HitClip;
        GameAudio.Play();
        Invoke("HitMusic", 1f);
    }

    public void FireType()
    {
        fire_type = Random.Range(1, 100);
        fire_type_check = true;
    }

    public void BonusSound()
    {
        GameAudio.clip = BonusClip;
        GameAudio.Play();
    }

    public void HitMusic()
    {
        GameAudio.clip = HitMusicClip;
        GameAudio.Play();
    }

    public void AddScore(int newscore)
    {
        score += newscore;
        ScoreText.text = string.Format("Score : {0}", score);
    }

    public void AddBonus(int newbonus)
    {
        score += newbonus;
        ScoreText.text = string.Format("Score : {0}", score);
    }
}
