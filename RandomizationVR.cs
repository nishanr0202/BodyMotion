public class Randomization : StateMachineBehavior
{
  private Animator anim;
  private List<int> used = new List<int>();
  private int min = 1
  private int max = 25 //Value should be one number higher than total actions (non-exclusive)

  private float loopDuration = 5f; //5 seconds 
  private float timer = 0f;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    timer += Time.deltaTime;

    if (timer >= loopDuration)
    {
      timer = 0f;
      animator.SetTrigger("End")
    }
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
      used.Clear()
    }

    return next;
  }

  private void SetNextMotion()
  {
    int next = GetUnique();
    anim.SetInteger("random_index", next);
  }
}
