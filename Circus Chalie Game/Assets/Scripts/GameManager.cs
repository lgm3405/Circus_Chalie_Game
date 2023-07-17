using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioClip BonusClip;
    public AudioClip HitClip;
    public AudioClip HitMusicClip;
    public AudioClip ClearClip;
    public Text TimeText;
    public Text ScoreText;
    public GameObject gameoverUi;
    public GameObject gameclearUi;
    public bool isGameOver = false;
    public bool isGameClear = false;
    public bool isGrounded = false;
    public bool isDead = false;
    public bool max_loop = false;
    public bool wall = false;
    public bool fire_type_check = false;
    public int loop_count = default;
    public int fire_type = 0;
    public float spawn_cooltime = default;
    public float speed = default;
    public int step = default;

    private AudioSource GameAudio = default;
    private float game_time = 0;
    private float check_time = 1f;
    private int second_time = 0;
    private int minute_time = 0;
    private int score = 0;

    private void Awake()
    {
        loop_count = 0;
        speed = 3f;
        spawn_cooltime = 3f;
        step = 1;

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
        if (isGameOver == false && isGameClear == false)
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
        else if (isGameClear == true && Input.GetKeyDown(KeyCode.R))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }

    public void OnPlayerClear()
    {
        GameAudio.clip = ClearClip;
        GameAudio.Play();
        GameAudio.loop = true;
        gameclearUi.SetActive(true);
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        GameAudio.clip = HitClip;
        GameAudio.Play();
        Invoke("HitMusic", 0.5f);
        gameoverUi.SetActive(true);
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
