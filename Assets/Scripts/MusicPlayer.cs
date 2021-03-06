using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	private static MusicPlayer instance = null;

	void Awake ()
	{
		if (instance)
			Destroy (gameObject);
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
