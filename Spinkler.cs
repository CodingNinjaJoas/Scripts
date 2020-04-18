using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinkler : MonoBehaviour
{
	public float speed;
	public float delay;
	public GameObject player;
	public float hitDelay;
	private float hittedDelay;
	private void Start()
	{
		InvokeRepeating("Move",delay,delay);
	}
	private void Move()
	{
		if(player.transform.position.x <=this.transform.position.x)
		{
			this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0);
		}
		if (player.transform.position.x >= this.transform.position.x)
		{
			this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		}
	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (hittedDelay <= 0)
		{
			if (collision.transform.CompareTag("Player") == true)
			{
				player.GetComponent<PlayerMovement>().health--;
				hittedDelay = hitDelay;
			}
			if (collision.transform.CompareTag("Fimbledore") == true)
			{
				player.GetComponent<PlayerMovement>().health--;
				hittedDelay = hitDelay;
			}
		}
	}
	private void Update()
	{
		hittedDelay -= Time.deltaTime;
	}
}
