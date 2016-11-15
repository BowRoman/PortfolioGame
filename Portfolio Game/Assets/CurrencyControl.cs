using UnityEngine;
using System.Collections;

public class CurrencyControl : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			PlayerControl player = col.gameObject.GetComponent<PlayerControl>();
			player.IncreaseCurrency(100);
			Destroy(gameObject);
		}
	}
}
