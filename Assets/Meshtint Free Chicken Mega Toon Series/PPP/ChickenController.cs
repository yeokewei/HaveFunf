using System.Collections;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public Animator chickenAnimator;

    private void Start()
    {
        // Get the Animator component of the chicken GameObject
        chickenAnimator = GetComponent<Animator>();

        // Start the animation coroutine
        StartCoroutine(AnimateChicken());
    }

    private IEnumerator AnimateChicken()
    {
        while (true)
        {
            // Generate a random value to decide the next action
            int randomAction = Random.Range(0, 4);

            // Set the appropriate animation conditions based on the random action
            chickenAnimator.SetBool("Walk", randomAction == 0);
            chickenAnimator.SetBool("Run", randomAction == 1);
            chickenAnimator.SetBool("Eat", randomAction == 2);
            chickenAnimator.SetBool("Turn Head", randomAction == 3);

            // Wait for a random amount of time before changing the animation
            float randomDelay = Random.Range(2f, 5f);
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
