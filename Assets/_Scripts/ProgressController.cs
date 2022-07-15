using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    //каждые 5 очков увеличивать скорость врагов
    //[SerializeField] private ScoreController scoreController;
    [SerializeField] public float forcePower {get; private set;} = 4.0f;
    [SerializeField] public float playerSpeedRotation {get; private set;} = 5.0f;
    [SerializeField] public float secBetweenSpawn {get; private set;} = 4.5f;
    [SerializeField] public float percentBonus{get; private set;} = 85.0f;
    [SerializeField] public int level {get; private set;} = 0;
    [SerializeField] public float trailTime {get;private set;} = 0.8f;

    public void LevelUp()
    {
        this.level++;
        this.secBetweenSpawn -= 0.5f;
        this.forcePower += 1f;
        this.percentBonus -= 5.0f;
        trailTime -= 0.1f;
    }
}
