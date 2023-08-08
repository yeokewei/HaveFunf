using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Playercollide : MonoBehaviour
{
   public int damageAmount = 10;
   public AudioSource source;
   public AudioClip gethitSound;

   // on trigger enter is for one time damage
   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.tag == "Walls")
      {
         source.PlayOneShot(gethitSound);
         Debug.Log("got hit");
         Health health = GetComponent<Health>();
         if (health != null)
         {
            Debug.Log("Take Damage");
            health.DamagePlayer(damageAmount);
            Destroy(other.gameObject);
         }

      }
   }

   void OnTriggerStay(Collider other) // this is for continuous damage
   {
      if (other.gameObject.tag == "Walls")
      {
         // Debug.Log("STAY");

      }
   }

   void OnTriggerExit(Collider other) // this is for continuous damage
   {
      if (other.gameObject.tag == "Walls")
      {
         // Debug.Log("EXIT");
      }
   }
}
