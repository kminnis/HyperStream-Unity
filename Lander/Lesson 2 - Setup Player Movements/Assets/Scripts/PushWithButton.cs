using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PushWithButton : MonoBehaviour 
{
	[Header("Input key")]
	public KeyCode Key = KeyCode.Space;

	[Header("Direction and strength")]
	public float PushStrength = 5f;
    public Axes Axis = Axes.Y;
	public bool RelativeAxis = true;


	private bool _keyPressed = false;
	private Vector2 _pushVector;

    public enum Axes
    {
        X,
        Y
    }

    [HideInInspector]
    public new Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Read the input from the player
    void Update()
	{
		_keyPressed = Input.GetKey(Key);
	}


	// FixedUpdate is called every frame when the physics are calculated
	void FixedUpdate()
	{
		if(_keyPressed)
		{
			_pushVector = GetVectorFromAxis(Axis) * PushStrength;

			//Apply the push
			if(RelativeAxis)
			{
				rigidbody2D.AddRelativeForce(_pushVector);
			}
			else
			{
				rigidbody2D.AddForce(_pushVector);
			}
		}
	}

    public static Vector2 GetVectorFromAxis(Axes axis)
    {
        if (axis == Axes.X)
        {
            return Vector2.right;
        }
        return Vector2.up;
    }
}
