using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

	public float timer;
	public GameObject bullet;
	public GameObject missile;
	public float bulletRange;

	public enum WeaponType { Standard, Shotgun, Missile };
	public WeaponType weaponType;
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0)
		{
			timer -= Time.deltaTime;
		}
		if (timer < 0)
		{
			if (Input.GetAxis("HorizontalShoot") > 0.25f)
			{
				Fire(Vector2.right);
			}
			else if (Input.GetAxis("HorizontalShoot") < -0.25f)
			{
				Fire(Vector2.left);
			}
			else if (Input.GetAxis("VerticalShoot") > 0.25f)
			{
				Fire(Vector2.up);
			}
			else if (Input.GetAxis("VerticalShoot") < -0.25f)
			{
				Fire(Vector2.down);
			}

			if (Input.GetAxis("Fire1") > 0.25f)
			{
				weaponType = WeaponType.Standard;
			}
			if (Input.GetAxis("Fire2") > 0.25f)
			{
				weaponType = WeaponType.Shotgun;
			}
			if (Input.GetAxis("Fire3") > 0.25f)
			{
				weaponType = WeaponType.Missile;
			}
		}
	}

	private void Fire(Vector2 direction)
	{
		switch (weaponType)
		{
			case WeaponType.Standard:
				StandardShoot(direction);
				break;
			case WeaponType.Shotgun:
				// unfortunately I didn't get to implementing the shotgun before the deadline
				// it would have been a simple 
				break;
			case WeaponType.Missile:
				MissileLaunch();
				break;
			default:
				break;
		}
	}


	private void StandardShoot(Vector2 direction)
	{
		GameObject projectile;

		projectile = Instantiate(bullet, this.transform.position, this.transform.rotation);

		projectile.GetComponent<Bullet>().moveDirection = direction;
		timer = 1;
		Destroy(projectile, 1f);
	}

	private void MissileLaunch()
	{
		GameObject projectile;

		Enemy[] enemies = FindObjectsOfType<Enemy>();
		Enemy closest = enemies[0];

		foreach (Enemy e in enemies)
		{
			if (Vector2.Distance(transform.position, e.transform.position) < Vector2.Distance(transform.position, closest.transform.position))
			{
				closest = e;
			}
		}

		projectile = Instantiate(missile, this.transform.position, this.transform.rotation);
		projectile.GetComponent<Missile>().target = closest.transform;

		timer = 2;
	}
}
