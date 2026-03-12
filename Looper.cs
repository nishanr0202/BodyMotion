using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : StateMachineBehaviour
{
  private Animator anim;
  private float loopDuration = 30f; //30 seconds
  private float timer = 0f;

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    timer += Time.deltaTime;
    if (timer >= loopDuration)
    {
      timer = 0f;
      animator.SetTrigger("End");
    }
  }
}
