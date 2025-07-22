using UnityEngine;

public class OnTrigger : MonoBehaviour
{
   [SerializeField] private Animator animator;

   void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         animator.SetTrigger("OpenChest");
      }
   }
}
