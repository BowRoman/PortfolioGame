using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GunControl : MonoBehaviour {

    [SerializeField]
	int gunDamage = 50;
    [SerializeField]
    float fireRate = 0.2f;
    [SerializeField]
    float weaponRange = 100.0f;
    [SerializeField]
    Transform endOfGun;

    //[SerializeField]
	//Animator myAnimator;

	[SerializeField]
	AudioSource myAudioSource;

	private Camera PlayerFPSCamera;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.03f);
    private LineRenderer shotLine;
    private float nextFire;

	// Use this for initialization
	void Start ()
	{
        shotLine = GetComponent<LineRenderer>();
        PlayerFPSCamera = GetComponentInParent<Camera>();
        myAudioSource.time = 0.5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
		{
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = PlayerFPSCamera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
			RaycastHit hit;

            shotLine.SetPosition(0, endOfGun.position);
			if(Physics.Raycast(rayOrigin, PlayerFPSCamera.transform.forward, out hit, weaponRange))
			{
				GameObject target = hit.collider.transform.gameObject;
				print(target.name);
				Enemy enemy = target.GetComponent<Enemy>();
				if(target.tag == "Enemy_Head")
				{
					target = target.transform.root.gameObject;
					enemy = target.GetComponent<Enemy>();
					enemy.Damage(gunDamage*2);
				}
				else if (target.tag == "Enemy_Body")
				{
					target = target.transform.root.gameObject;
					enemy = target.GetComponent<Enemy>();
					enemy.Damage(gunDamage);
				}
				else if(enemy)
				{
					enemy.Damage(gunDamage);
				}
                shotLine.SetPosition(1, hit.point);
			}
            else
            {
                shotLine.SetPosition(1, rayOrigin + (PlayerFPSCamera.transform.forward * weaponRange));
            }
		}
	}

    private IEnumerator ShotEffect()
    {
        //myAnimator.SetTrigger("Shoot");
        myAudioSource.Play();

        shotLine.enabled = true;
        yield return shotDuration;
        shotLine.enabled = false;
    }
}
