using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float range;
	public PlayerMovement player;
	public FimbleDore target;
	public CameraShake cameraS;
	private void Start()
	{

		if (Physics2D.OverlapCircle(transform.position, range))
		{
			Collider2D collision = Physics2D.OverlapCircle(transform.position, range);
			if (collision.CompareTag("Player") == true)
			{
				player.health--;
				StartCoroutine(cameraS.Shake());
				StartCoroutine(player.GotHit());
				StartCoroutine(player.ColorChange());
			}
			if (collision.CompareTag("FimbleDore") == true)
			{
				target.health--;
				target.GotHit();
			}

		}
				
			
	}

}
