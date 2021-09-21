using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public IEnumerator Won()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSeconds(2f);
        LoadMenu();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        StartCoroutine(Load());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    private IEnumerator Load()
 {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        	while (!asyncLoad.isDone) 
		{
			yield return null;
		}
	
 }
}
