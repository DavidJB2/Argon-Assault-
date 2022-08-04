using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LoadDelay = 1f;
    [SerializeField]  ParticleSystem CrashVFX;
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + "-- Collided with --" + other.gameObject.name);    
    }
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");

        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        CrashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Player1Control>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("ReloadLevel", LoadDelay); 
    }

        void ReloadLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }


}
