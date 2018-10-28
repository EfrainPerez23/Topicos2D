using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int health;
	public int hearthNumbers;
	public Image[] hearths;
	public Sprite fullHearth;
	public Sprite emptyHearth;

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{

		if (this.health > this.hearthNumbers) {
			this.health = this.hearthNumbers;
		}

		for(int i = 0; i < this.hearths.Length; i++) {

			if (i < this.health) {
				this.hearths[i].sprite = this.fullHearth;
			} else {
				this.hearths[i].sprite = this.emptyHearth;
			}
			

			if (i <= this.hearthNumbers) {
				this.hearths[i].enabled = true;
			} else {
				this.hearths[i].enabled = false;
			}
		}
	}	
	
}
