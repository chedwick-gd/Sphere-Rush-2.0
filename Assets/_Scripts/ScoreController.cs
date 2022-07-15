using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    [SerializeField] private ProgressController progressController;
    [SerializeField] public int scorePoint {get; private set;}
    [SerializeField] public float scoreTime {get; private set;}
    [SerializeField] public float percentBonus{get; private set;} = 90.0f;

    void Update()
    {
        this.scoreTime += Time.deltaTime;
    }
    //--point control
    public void AddPoint()
    {
        this.scorePoint++;
        if (this.scorePoint % 5 == 0)
        {
            progressController.LevelUp();
        }
    }

    public void ResetPoint()
    {
        this.scorePoint = 0;
        this.scoreTime = 0f;
    }

    public void RemovePoint()
    {
        this.scorePoint--;
    }
    //--score control
    public void SaveBestScore()
    {
        int lastScorePoint = PlayerPrefs.GetInt("ScorePoint");
        float lastScoreTime = PlayerPrefs.GetFloat("ScoreTime");

        if (lastScorePoint < this.scorePoint)
        {
            PlayerPrefs.SetInt("ScorePoint",this.scorePoint);
        }
        if (lastScoreTime < this.scoreTime)
        {
            PlayerPrefs.SetFloat("ScoreTime",this.scoreTime);
        }
    }

    public void LoadBestScore()
    {
        this.scorePoint = PlayerPrefs.GetInt("ScorePoint");
        this.scoreTime = PlayerPrefs.GetFloat("ScoreTime");
    }

    public void DeleteScore()
    {
        PlayerPrefs.DeleteKey("ScorePoint");
        PlayerPrefs.DeleteKey("ScoreTime");
        this.scorePoint = PlayerPrefs.GetInt("ScorePoint");
        this.scoreTime = PlayerPrefs.GetFloat("ScoreTime");
    }

}
