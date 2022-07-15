using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private ProgressController progressController;
    [SerializeField] private GameObject enemyProp;
    [SerializeField] private GameObject[] propTypes;
    [SerializeField] private Vector2 enemyStartPosMinMax = new Vector2(-5,5);
    [SerializeField] private enum SceneName
    {
        StartScene,
        GameScene,
        EndScene
    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == SceneName.GameScene.ToString())
        {
            scoreController.ResetPoint();
            StartCoroutine(EnemySpawn());
        }   
        else if(SceneManager.GetActiveScene().name == SceneName.EndScene.ToString())
        {
            scoreController.LoadBestScore();
        }            
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name == SceneName.EndScene.ToString() && Input.GetKeyDown(KeyCode.Space))
        {
            this.RestartTheGame();
        }
    }

    private IEnumerator EnemySpawn()
    {
        float enemyStartPos = Random.Range(enemyStartPosMinMax.x,enemyStartPosMinMax.y);

        //контролируемый рандом выпадения бонусов/врагов
        float randomSid = 100.0f - Random.Range(0,100); //рандомное значение в процентах
        if (randomSid >= progressController.percentBonus) //80% шанс что - больше 80 
        {
            enemyProp = propTypes[0];
        }
        else
        {
            enemyProp = propTypes[1];
        }

        enemyProp = Instantiate<GameObject>(enemyProp,new Vector3(-20,enemyStartPos,-3),Quaternion.identity);
        enemyProp.GetComponent<Rigidbody>().AddForce(Vector3.right * progressController.forcePower,ForceMode.VelocityChange);
        enemyProp.GetComponent<TrailRenderer>().time = progressController.trailTime;
        yield return new WaitForSeconds(progressController.secBetweenSpawn);
        
        StartCoroutine(EnemySpawn());
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0;
        GameObject.FindWithTag("PauseUI").GetComponent<Canvas>().enabled = true;
    }

    public void ResumeTheGame()
    {
        Time.timeScale = 1;
        GameObject.FindWithTag("PauseUI").GetComponent<Canvas>().enabled = false;
    }

    public void StartTheGame()
    {
        Time.timeScale = 1;
        scoreController.ResetPoint();
        SceneManager.LoadScene(SceneName.GameScene.ToString());
    }

    public void RestartTheGame()
    {
        Time.timeScale = 1;
        scoreController.ResetPoint();
        SceneManager.LoadScene(SceneName.GameScene.ToString());
    }

    public void EndTheGame()
    {
        Time.timeScale = 0;
        scoreController.SaveBestScore();
        SceneManager.LoadScene(SceneName.EndScene.ToString());
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
