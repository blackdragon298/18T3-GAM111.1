using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public bool gameDisplay;
	public Image[] healthSprites;
	public Text scoreDisplay;
	public Text weaponDisplay;

	public GameObject player;
	public ScoreManager scoreManager;
	
	// Update is called once per frame
	void Update () {
		if (gameDisplay)
		{
			scoreDisplay.text = ("Score: " + scoreManager.GetScore());
			UpdateHealthDisplay();
			UpdateWeaponDisplay();
		}

	}

	private void UpdateHealthDisplay()
	{
		for (int i = 0; i < healthSprites.Length; i++)
		{
			if (i + 1 > player.GetComponent<Health>().GetHealth())
			{
				healthSprites[i].enabled = false;
			}
			else
			{
				healthSprites[i].enabled = true;
			}
		}
	}

	private void UpdateWeaponDisplay()
	{
		switch (player.GetComponent<PlayerWeapon>().weaponType)
		{
			case PlayerWeapon.WeaponType.Standard:
				weaponDisplay.text = "Weapon: Standard";
				break;
			case PlayerWeapon.WeaponType.Shotgun:
				weaponDisplay.text = "Shotgun not implimented";
				break;
			case PlayerWeapon.WeaponType.Missile:
				weaponDisplay.text = "Weapon: Missile";
				break;
			default:
				break;
		}
	}
}
