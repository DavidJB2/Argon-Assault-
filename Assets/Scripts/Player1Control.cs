using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour
{
   
     [Header("General Setup Settings")]
     [Tooltip("How fast ship moves up and down based on player input")] 
     [SerializeField]  float controlSpeed = 10f;
    [Tooltip("How fast player moves horizontally")]
    [SerializeField]  float xRange = 5f;
    
   [Tooltip("How fast player moves vertically")]
   [SerializeField] float yRange = 3.5f;

     [Header("Laser gun array")]

     [Tooltip("Add all player lasers here")]
     [SerializeField] GameObject[] lasers;

     [Header("Screen position based on turning")]
     
     [SerializeField] float positionPitchFactor = -2f;
     [SerializeField] float positionYawFactor = -5f;
     
    [Header("Player input based turning")]
     [SerializeField] float controlPitchfactor = -10f;
     
     [SerializeField] float controlRollFactor = 5f; 

     float yThrow, xThrow;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    
    void ProcessRotation()
    {

       float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
       float pitchDueToControl = yThrow * controlPitchfactor;
       float pitch = pitchDueToPosition + pitchDueToControl;
       float yaw = transform.localPosition.x * positionYawFactor;
       float roll = xThrow * controlRollFactor;


       transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }
    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clamedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clamedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
           SetlasersActive(true);
        }

        else
        {
           SetlasersActive(false);
             
        }
        
    
        void SetlasersActive(bool isActive)
        {
           foreach (GameObject laser in lasers)
           {
          
           var emissionModule = laser.GetComponent<ParticleSystem>().emission; 
           emissionModule.enabled = isActive;

           }
        }

     

        

    }

}
