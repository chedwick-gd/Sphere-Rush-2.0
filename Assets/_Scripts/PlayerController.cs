using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ProgressController progressController;
    [SerializeField] private float speedRotation;
    [SerializeField] private float angleRotation = 45.0f;

    void Update()
    {
        this.speedRotation = progressController.playerSpeedRotation;
        
        Vector3 rotationDirection = new Vector3(0,0,angleRotation*speedRotation);

        this.transform.Rotate(rotationDirection*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            angleRotation *= -1;
        }
    }
}
