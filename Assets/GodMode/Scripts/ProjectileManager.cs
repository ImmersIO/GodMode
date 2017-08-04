using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {


	[SerializeField]
	private GameObject m_projectile;

	[SerializeField]
	private float m_velocity = 500.0f;

	[SerializeField]
	private float m_lifetime = 10.0f;

	[SerializeField]
	private float m_distance = 10.0f;


	public GameObject projectile;
	public float bulletSpeed = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*foreach (var touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {

				// Instantiate the projectile at the position and rotation of this transform
				Transform clone;
				Vector3 p = Camera.main.ScreenToWorldPoint (Vector3 (touch.position.x,touch.position.y,0));

				clone = Instantiate(projectile, p.po, p.rotation);

				// Add force to the cloned object in the object's forward direction
				clone.rigidbody.AddForce(clone.transform.forward * shootForce); 

			}
		}

		if (Input.GetMouseButtonDown(0)) {

			// Instantiate the projectile at the position and rotation of this transform
			Transform clone;
			Vector3 p = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x,Input.mousePosition.y,0));

			clone = Instantiate(projectile, p.position, p.rotation);

			// Add force to the cloned object in the object's forward direction
			clone.rigidbody.AddForce(clone.transform.forward * shootForce);
		}*/

		foreach (var touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				
				var screenTouchPos = new Vector3 (touch.position.x, touch.position.y, Camera.main.nearClipPlane);
				var rayThroughCamera = Camera.main.ScreenPointToRay (screenTouchPos);            
				GameObject projectile = Instantiate (m_projectile, transform.position, Quaternion.LookRotation (rayThroughCamera.direction)) as GameObject;
				projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * m_velocity;
				//projectile.GetComponent<Projectile>().Lifetime = m_lifetime;
			}
		}


		if (Input.GetButtonDown("Fire1"))
		{
			var screenSpaceMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
			var rayThroughCamera = Camera.main.ScreenPointToRay(screenSpaceMousePosition);            
			GameObject projectile = Instantiate(m_projectile, transform.position, Quaternion.LookRotation(rayThroughCamera.direction)) as GameObject;
			projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * m_velocity;
			//projectile.GetComponent<Projectile>().Lifetime = m_lifetime;
		}
			

	}
}
