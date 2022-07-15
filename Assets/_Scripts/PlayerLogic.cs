using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private ScoreController scoreControll;
    [SerializeField] private SceneController sceneController;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy")
        {
            sceneController.EndTheGame();
        }
        else if (other.gameObject.tag == "Bonus")
        {
            scoreControll.AddPoint();
            Destroy(other.gameObject);
        }
        
    }
}
