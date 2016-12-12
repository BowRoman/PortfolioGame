using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[SerializeField]
	int Health = 100;
    [SerializeField]
    int DamageDealt = 10;

	[SerializeField]
	GameObject Drop;
	[SerializeField]
	int MinimumDrops;
	[SerializeField]
	int MaximumDrops;

    [SerializeField]
    Transform Target;

	private int DropAmount;

    void Start()
	{
		DropAmount = Random.Range(MinimumDrops, MaximumDrops);
	}
	
	void Update()
	{
        if(Target)
        {
            GetComponent<NavMeshAgent>().SetDestination(Target.position);
        }
	}

    public void SetTarget(Transform newTarget)
    {
        Target = newTarget;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Objective")
        {
            // explode self to damage core
            other.gameObject.GetComponent<ObjectiveControl>().Damage(DamageDealt);
            Destroy(gameObject);
        }
    }

	public void Damage(int points)
	{
		Health -= points;
		if(Health <= 0)
		{
			for(int i = 0; i < DropAmount; ++i)
			{
				Instantiate(Drop, transform.position + new Vector3(Random.Range(-0.6f,0.6f),0.4f,Random.Range(-0.6f, 0.6f)), transform.rotation);
			}
			Destroy(gameObject);
		}
	}
}
