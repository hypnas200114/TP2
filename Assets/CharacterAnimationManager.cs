using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Impact");
        Debug.Log("Ouch");
    }

}
