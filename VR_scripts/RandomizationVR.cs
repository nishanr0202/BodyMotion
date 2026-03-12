using UnityEngine;
using System.Collections.Generic;

public class Randomization : StateMachineBehaviour
{
  private Animator anim;
  private List<int> used = new List<int>();
  private int min = 1;
  private int max = 25; //Value should be one number higher than total actions (not inclusive)

  private float loopDuration = 5f; //5 seconds 
  private float timer = 0f;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    anim = animator;
    timer = 0f; //make sure it's zeroed out
    SetNextMotion();
  }
  
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    timer += Time.deltaTime;

    if (timer >= loopDuration)
    {
      timer = 0f; //to make sure it doesn't affect timers in other parts of controller
      anim.SetTrigger("End");
    }
  }

  private void SetNextMotion()
  {
    int next = GetUnique();
    anim.SetInteger("random_index", next);
  }

  private int GetUnique()
  {
    int next = Random.Range(min, max);

    while (used.Contains(next))
    {
      next = Random.Range(min, max);
    }

    used.Add(next);
    if (used.Count >= max - 1)
    {
      used.Clear();
    }

    return next;
  }
}
