using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;

    private void Awake()
    {
        if (instance.isValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isGameOver == true && Input.GetMouseButton(0))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }
}
