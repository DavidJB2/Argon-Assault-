using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

   [SerializeField] GameObject deathVFX;
   [SerializeField] Transform parent;
   [SerializeField] int scorePerHit = 15;

   ScoreBoard ScoreBoard;

   void Start()
   {
      ScoreBoard = FindObjectOfType<ScoreBoard>();
   }
   
   private void OnParticleCollision(GameObject other) 
   {  
      ScoreBoard.increaseScore(scorePerHit);
      GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
      vfx.transform.parent = parent;
      Debug.Log($"{name}I'am hit by {other.gameObject.name}");
      Destroy(gameObject);
  }
}
