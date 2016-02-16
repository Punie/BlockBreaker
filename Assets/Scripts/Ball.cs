using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public float maxSpeed = 10f;

	private bool hasStarted = false;
	private Rigidbody2D rb;
	private AudioSource boingSound;
	private Paddle paddle;
	private Vector3 paddleToBallVector;


	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		boingSound = GetComponent<AudioSource> ();

		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	void Update ()
	{
		if (!hasStarted)
		{
			transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0))
			{
				hasStarted = true;
				rb.velocity = Vector2.one * maxSpeed;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (hasStarted && collision.gameObject.layer != LayerMask.NameToLayer ("Brick"))
			boingSound.Play ();
	}
}
