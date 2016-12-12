using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectiveControl : MonoBehaviour {

    [SerializeField]
    Image CoreHealthBar;
    [SerializeField]
    int CoreHealth = 100;

    int CurrentHealth;

	void Start()
    {
        CurrentHealth = CoreHealth;
	}
	
	void Update()
    {
	
	}

    public void Damage(int points)
    {
        CurrentHealth -= points;
        CoreHealthBar.fillAmount = ((float)CurrentHealth / (float)CoreHealth);
    }
}
