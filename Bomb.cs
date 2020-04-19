using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (hittedDelay <= 0)
		{
			if (collision.transform.CompareTag("Player") == true)
			{
				player.GetComponent<PlayerMovement>().health--;
				hittedDelay = hitDelay;
				StartCoroutine(cameraS.Shake());
				StartCoroutine(player.GetComponent<PlayerMovement>().GotHit());
				StartCoroutine(player.GetComponent<PlayerMovement>().ColorChange());

			}
			if (collision.transform.CompareTag("Fimbledore") == true)
			{
				target.GetComponent<FimbleDore>().health--;
				target.GetComponent<FimbleDore>().GotHit();
				hittedDelay = hitDelay;
			}
		}
	}
	private void Update()
	{
		hittedDelay -= Time.deltaTime;
	}
}
