using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinkler : MonoBehaviour
{
	public float speed;
	public float health;
	public float delay;
	public Vector2 hitForce;
	public float shakeMag;
	public float shakeDur;
	public GameObject player;
	public GameObject coin;
	public Transform coinSpawnpoint;
	public Transform coinHolder;
	public GameObject target;
	public CameraShake cameraS;
	public float hitDelay;
	private float hittedDelay;
	private void Start()
	{
		InvokeRepeating("Move",delay,delay);
	}
	private void Move()
	{
		if(target.transform.position.x <=this.transform.position.x)
		{
			this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,0);
		}
		if (target.transform.position.x >= this.transform.position.x)
		{
			this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("WeaponCollider") == true)
		{
			health--;
			if (player.transform.position.x >= this.transform.position.x)
			{
				this.gameObject.GetComponent<Rigidbody2D>().AddForce(-hitForce);
			}
			else
			{
				this.gameObject.GetComponent<Rigidbody2D>().AddForce(hitForce);
			}
		}
		if (other.CompareTag("InstaKill") == true)
		{
			Destroy(this.gameObject,0.2f);
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
				StartCoroutine(cameraS.Shake());
				StartCoroutine(player.GetComponent<PlayerMovement>().GotHit());
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
		if(health <= 0)
		{
			GameObject g = Instantiate(coin,coinHolder);
			g.transform.position = coinSpawnpoint.transform.position;
			Destroy(this.gameObject);
		}
		hittedDelay -= Time.deltaTime;
	}
}
