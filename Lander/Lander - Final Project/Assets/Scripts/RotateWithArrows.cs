using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateWithArrows : MonoBehaviour
{
	[Header("Input keys")]
	public KeyGroups TypeOfControl = KeyGroups.ArrowKeys;

	[Header("Rotation")]
	public float Speed = 5f;	
	private float _spin;

    public enum KeyGroups
    {
        ArrowKeys,
        WASD,
    }

    [HideInInspector]
    public new Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update ()
	{	
		if(TypeOfControl == KeyGroups.ArrowKeys)
		{
			_spin = Input.GetAxis("Horizontal");
		}
		else
		{
			_spin = Input.GetAxis("Horizontal2");
		}
	}
	
	void FixedUpdate ()
	{
		rigidbody2D.AddTorque(-_spin * Speed);
	}
}
