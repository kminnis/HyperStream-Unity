using UnityEngine;

public class DestroyAction : Action
{

    public enum Targets
    {
        ThisObject,
        ObjectThatCollided,
    }

    public Targets target = Targets.ObjectThatCollided;
	public GameObject DeathEffect;

	public override bool ExecuteAction(GameObject other)
	{
		if(DeathEffect != null)
		{
			var newObject = Instantiate<GameObject>(DeathEffect);
			newObject.transform.position = (target == Targets.ObjectThatCollided) ? other.transform.position : this.transform.position;
		}

		if(target == Targets.ObjectThatCollided)
		{
		    if(other != null)
			{
				Destroy(other);
				return true;
			}
		    return false;
		}
	    Destroy(gameObject);
	    return true;
	}

}

public class Action : MonoBehaviour
{
    public virtual bool ExecuteAction(GameObject other)
    {
        return true;
    }
}