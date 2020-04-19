using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float range;
	public PlayerMovement player;
	public FimbleDore target;
	public CameraShake cameraS;
	public GameObject explosionFX;
	public Transform holderFX;
	public GameObject damageFX;
	private void Start()
	{
		
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
	
			if (Physics2D.OverlapCircle(transform.position, range))
			{
				GameObject g = Instantiate(explosionFX, holderFX);
				g.transform.position = this.transform.position;
				g.GetComponent<DestroyFX>().destroyFX = true;
				Collider2D collision = Physics2D.OverlapCircle(transform.position, range);
				if (collision.CompareTag("Player") == true)
				{
				GameObject f =Instantiate(damageFX, holderFX);
				f.GetComponent<DestroyFX>().destroyFX = true;
				player.health--;
					StartCoroutine(cameraS.Shake());
					StartCoroutine(player.GotHit());
					StartCoroutine(player.ColorChange());
				}
				if (collision.CompareTag("Fimbledore") == true)
				{
					target.health--;
					StartCoroutine(target.GotHit());
				}
				Destroy(this.gameObject);

			}
		
		
	
	}


}
