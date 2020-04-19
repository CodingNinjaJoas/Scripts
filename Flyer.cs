﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
	public float speed;
	public float health;
	public Vector2 hitForce;
	public GameObject player;
	public GameObject coin;
	public Transform coinSpawnpoint;
	public Transform coinHolder;
	public GameObject target;
	public CameraShake cameraS;
	public GameObject bomb;
	public float hitDelay;
	private float hittedDelay;
	
	private void Start()
	{
		
	}
	private void Move()
	{
		if (player.GetComponent<PlayerMovement>().gamePause == false)
		{
			if (target.transform.position.x <= this.transform.position.x)
			{
				this.transform.position = new Vector3(this.transform.position.x-speed,this.transform.position.y,this.transform.position.z);
				this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
			
			}
			if (target.transform.position.x >= this.transform.position.x)
			{
				this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
				this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
				
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("WeaponCollider") == true)
		{
			health -= player.GetComponent<PlayerMovement>().damage;
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
			Destroy(this.gameObject, 0.2f);
		}
	}

	private void Update()
	{
		Move (); 
		if (health <= 0)
		{
			GameObject g = Instantiate(coin, coinHolder);
			g.transform.position = coinSpawnpoint.transform.position;
			Destroy(this.gameObject);
		}
		hittedDelay -= Time.deltaTime;
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