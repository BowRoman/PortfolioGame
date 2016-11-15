using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[SerializeField]
	int Health = 100;

	[SerializeField]
	GameObject Drop;
	[SerializeField]
	int MinimumDrops;
	[SerializeField]
	int MaximumDrops;

	private int DropAmount;

    // Use this for initialization
    void Start()
	{
		DropAmount = Random.Range(MinimumDrops, MaximumDrops);
	}
	
	// Update is called once per frame
	void Update()
	{
	}

	public void Damage(int points)
	{
		Health -= points;
		if(Health <= 0)
		{
			for(int i = 0; i < DropAmount; ++i)
			{
				Instantiate(Drop, transform.position + new Vector3(Random.Range(-0.6f,0.6f),0.1f,Random.Range(-0.6f, 0.6f)), transform.rotation);
			}
			Destroy(gameObject);
		}
	}
}
