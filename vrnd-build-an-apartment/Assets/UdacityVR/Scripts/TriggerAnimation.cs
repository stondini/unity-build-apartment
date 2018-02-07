using UnityEngine;
using System.Collections;

/// <summary>
/// The TriggerAnimation class activates a transition whenever the Cardboard button is pressed (or the screen touched).
/// </summary>
public class TriggerAnimation : MonoBehaviour
{
	[Tooltip ("The Animator component on this gameobject")]
	public Animator animator;
	[Tooltip ("The name of the Animator trigger parameter")]
	public string triggerName;

    private bool isAnimated = false;
    private float normalizedTime = 0.0F;

	void Update ()
	{
        int hash = Animator.StringToHash("Globe Animation");
        // Save the animation normalized time
        if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == hash)
        {
            this.normalizedTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }
		// If the player pressed the cardboard button (or touched the screen), set the trigger parameter to active (until it has been used in a transition)
		if (Input.GetMouseButtonDown (0)) {
            if (!this.isAnimated)
            {
                // Debug.Log("Restore: "+this.normalizedTime);
                animator.Play(hash, 0, this.normalizedTime);
            } else {
                // Debug.Log("Save: " + this.normalizedTime);
                animator.SetTrigger(triggerName);
            }

            this.isAnimated = !this.isAnimated;
		}
	}
}
