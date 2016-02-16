using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public AudioClip crackSound;
	public Color[] hitColor;

	public static int breakableCount = 0;

	private bool isBreakable;
	private int timesHit;
	private int maxHits;
	private SpriteRenderer spriteRenderer;

	void Start ()
	{
		isBreakable = (tag == "Breakable");
		timesHit = 0;
		maxHits = hitColor.Length;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.color = hitColor [timesHit];

		if (isBreakable)
			breakableCount++;
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint (crackSound, transform.position);
	}

	void OnCollisionExit2D (Collision2D collision)
	{
		if (isBreakable)
			HandleHits ();
	}

	void HandleHits ()
	{
		timesHit++;

		if (timesHit >= maxHits)
		{
			breakableCount--;
			Destroy (gameObject);
		}
		else
			spriteRenderer.color = hitColor [timesHit];
			
	}
}
