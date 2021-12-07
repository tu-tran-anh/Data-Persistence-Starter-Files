using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private string bestName;
    private int bestScore;
    private string name;
    [SerializeField] InputField nameInput;
    [SerializeField] TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    private void Start()
    {
        
        MenuManager.Instance.LoadBestPlay();

        bestScore = MenuManager.Instance.bestScore;
        bestName = MenuManager.Instance.bestName;
        bestScoreText.text = $"Best score : {bestName} {bestScore}";
        
    }
    public void NewNameEntered()
    {
        name = nameInput.text;
        MenuManager.Instance.playerName = name;
    }
    public void OnClickPlayBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickExitBtn()
    {
        //MenuManager.Instance.SaveBestPlay();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
