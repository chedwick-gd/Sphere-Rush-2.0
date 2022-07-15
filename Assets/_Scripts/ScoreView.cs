using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreController scoreControll;
    [SerializeField] private ProgressController progressController;
    [SerializeField] private Text scorePointTxt;
    [SerializeField] private Text scoreTimeTxt;
    [SerializeField] private Text scoreLvlTxt;
  
    void Start()
    {
        this.scorePointTxt.text = scoreControll.scorePoint.ToString();
        this.scoreTimeTxt.text = scoreControll.scoreTime.ToString("F2"); 
        if(scoreLvlTxt)
            this.scoreLvlTxt.text = progressController.level.ToString();
    }

    void Update()
    {
        this.scorePointTxt.text = scoreControll.scorePoint.ToString();
        this.scoreTimeTxt.text = scoreControll.scoreTime.ToString("F2"); 
        if(scoreLvlTxt)
            this.scoreLvlTxt.text = progressController.level.ToString();
    }

    
}
