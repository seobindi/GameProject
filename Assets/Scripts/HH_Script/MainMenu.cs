using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnclickShop()
    {
        Debug.Log("ªÛ¡°");
    }
    public void OnclickGamestart()
    {
        Debug.Log("»£√‚µ ");
        LoadingSceneManager.LoadScene("Game");
    }
    public void OnclickMainmenu()
    {
        LoadingSceneManager.LoadScene("mainmenu");
    }
    public void OnclickShopButton()
    {
        LoadingSceneManager.LoadScene("Shop");
    }

    public void OnclickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit():
#endif
    }
}
