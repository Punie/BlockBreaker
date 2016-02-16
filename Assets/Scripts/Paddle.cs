using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public bool autoPlay = false;

	private Ball ball;


	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	void Update ()
	{
		if (autoPlay)
			AutoPlay ();
		else
			PaddleMovement ();
	}

	void PaddleMovement ()
	{
		Vector3 paddlePos;
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		paddlePos = new Vector3 (Mathf.Clamp (mousePosInBlocks, 0.75f, 15.25f), transform.position.y, 0f);
		transform.position = paddlePos;
	}

	void AutoPlay ()
	{
		Vector3 paddlePos;
		float ballPosInBlocks = ball.transform.position.x;

		paddlePos = new Vector3 (Mathf.Clamp (ballPosInBlocks, 0.75f, 15.25f), transform.position.y, 0f);
		transform.position = paddlePos;
	}
}
