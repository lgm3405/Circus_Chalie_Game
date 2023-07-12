using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.PackageManager;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]

    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 현재 씬의 이름을 리턴한다.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    // 컴포넌트가 존재하는지 여부를 체크하는 함수
    public static bool isValid<T>(this T target) where T : Component
    {
        if (target == null || target == default) { return false; }
        else { return true; }
    }

    // 리스트가 존재하는지 여부를 체크하는 함수
    public static bool isValid<T>(this List<T> target)
    {
        bool isInValid = (target == null || target == default);
        isInValid = isInValid || target.Count == 0;

        if (isInValid == true) { return false; }
        else { return true; }
    }


}
