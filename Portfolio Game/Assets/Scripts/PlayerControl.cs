using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    [SerializeField]
    Text Points;

    string PointsBaseText = " Points";
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
        string newtext = (Currency.ToString() + PointsBaseText);
        Points.text = newtext;
        Points.transform.parent.gameObject.GetComponent<Text>().text = newtext;
    }
}
