using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	private int Currency = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncreaseCurrency(int amount)
	{
		Currency += amount;
	}
}
