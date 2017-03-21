using UnityEngine;
using System.Collections;

public class hookrotate : MonoBehaviour {

//	private Camera mainCamera;
	public float turnSpeed = 2f; 
	public float shrinkSpeed = 2f;
	private bool ishooking;
	private bool rolb, rorb;
	public Vector3 axisPosition;
	public Vector3 direction;
//	public int 3;
	public getMoney[] money;
	public static int totvalue = 0;
	private float lbound, rbound, bbound, tbound;
	private bool isover;
	private float pullSpeed;
	public bool pullback;
	public bool isget;
	public bool ison;
	public timer t;
	public AudioClip hooksound;
//	public bool isback;
//	public getMoney.gameObject currentobject;

	// Use this for initialization
	void Start () {
		axisPosition = transform.position;
		ishooking = false;
		rolb = rorb = false;
		lbound = -8.5f;
		rbound = 8.5f;
		bbound = -4.2f;
		tbound = 3.8f;
		isover = false;
		pullback = false;
		isget = false;
		ison = true;
	}

	// Update is called once per frame  
	void Update () {  
		ison = t.gameInProgress;
		if (ison == true) {
			if (Input.GetButton ("Fire1")){
				//begin hooking
				if (ishooking == false) {
					AudioSource.PlayClipAtPoint (hooksound, transform.position);
					ishooking = true;
				}
			}
	//		else if (transform.position.x < 0.1 && transform.position.x > -0.1 && transform.position.y < axisPosition.y + 0.02 && transform.position.y > axisPosition.y - 0.02) {
			else if (transform.position.y > tbound) {
				ishooking = false;
				isover = false;
				pullback = false;
				isget = false;
				//			Debug.Log ("===========");
			}
			//		Debug.Log (ishooking);
			//		Debug.Log (isover);
			
			if (ishooking == false) {
				transform.position = axisPosition;
				Vector3 mouseworldPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));  
				direction = mouseworldPos - transform.position;  
				direction.z = 0f;  
				direction.Normalize ();  
				float targetAngle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;  

				if (targetAngle < -15 && targetAngle > -165) {
					rolb = rorb = false;
					transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle + 90), turnSpeed);
				} else if (targetAngle >= -15 && rolb == false) {
					rorb = true;
				} else if (targetAngle <= -165 && rorb == false) {
					rolb = true;
				}
				if (rolb) {
					direction.y = Mathf.Sin (75);
					direction.x = -Mathf.Cos (75);
				}
				if (rorb) {
					direction.y = Mathf.Sin (75);
					direction.x = Mathf.Cos (75);
				}
				if (rolb && rorb)
					Debug.Log ("error");

			} else {
				if (isover == false) {
					int cur = -1;
					for (int i = 0; i < money.Length; i++) {
						if (money [i].iscatch == true) {
							cur = i;
							isget = true;
							break;
						}
					}
					if (cur == -1) {
						//					Debug.Log ("Forward");
						transform.Translate (direction * Time.deltaTime * shrinkSpeed, Space.World);
						if (transform.position.y < bbound || transform.position.x < lbound || transform.position.x > rbound) {

							isover = true;
						}
					} else {
						pullSpeed = money [cur].curspeed;
						pullback = true;
						transform.Translate (-direction * pullSpeed * Time.deltaTime, Space.World);
					}
				} else {
					pullback = true;
					transform.Translate (-direction * shrinkSpeed * Time.deltaTime, Space.World);
				}
				//			Debug.Log (direction);
			}

		}
	}
}