using UnityEngine;
using System.Collections;

public class getMoney : MonoBehaviour {

	public bool iscatch;
	private Vector3 rise;
	private Vector3 initdirw;
	private Vector3 initdirb;
	public hookrotate h;
	public Vector3 startpoint;
	private float coinspeed, boxspeed, billspeed, diamondspeed, walletspeed, packagespeed;
	private int coinvalue, boxvalue, billvalue, diamondvalue, walletvalue, packagevalue;
	private float lbound, rbound, bbound, mtbound;
	public float curspeed;
	private bool rightward;
	private bool upward;
	private int wallethrzspeed;
	private int billvtcspeed;
	public int curvalue;
	private AudioClip moneysound;
	public AudioClip coinsound, walletsound, pkgsound, diamondsound, boxsound, billsound;


	// Use this for initialization
	void Start () {
		iscatch = false;
		startpoint = h.gameObject.transform.position;
		coinspeed = 3f;
		boxspeed = 0.8f;
		billspeed = 5f;
		diamondspeed = 3f;
		walletspeed = 1.5f;
		packagespeed = 3f;
		coinvalue = 10;
		boxvalue = 500;
		billvalue = 500;
		diamondvalue = 1000;
		walletvalue = 250;
		lbound = -8.5f;
		rbound = 8.5f;
		bbound = -4.2f;
		mtbound = 3f;
		initdirw = transform.right;
		initdirb = transform.up;
		rightward = true;
		upward = true;
		wallethrzspeed = Random.Range (1, 4);
		billvtcspeed = Random.Range (1, 4);
		curvalue = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (h.ison) {
//			Debug.Log ("========");
			if (iscatch) {
				rise = startpoint - transform.position;
				rise.z = 0;
//			Debug.Log (rise);
//			rise.Normalize();
				if (rise.x >= 0.1 || rise.x <= -0.1 || rise.y >= 0.1 || rise.y <= -0.1) {
					switch (gameObject.tag) {
					case("coin"):
						curspeed = coinspeed;
						curvalue = coinvalue;
						moneysound = coinsound;
						break;
					case("box"):
						curspeed = boxspeed;
						curvalue = boxvalue;
						moneysound = boxsound;
						break;
					case("bill"):
						curspeed = billspeed;
						curvalue = billvalue;
						moneysound = billsound;
						break;
					case("diamond"):
						curspeed = diamondspeed;
						curvalue = diamondvalue;
						moneysound = diamondsound;
						break;
					case("wallet"):
						curspeed = walletspeed;
						curvalue = walletvalue;
						moneysound = walletsound;
						break;
					case("package"):
						curspeed = packagespeed;
						curvalue = Random.Range (100, 800);
						moneysound = pkgsound;
						break;
					default:
						break;
					}
					transform.Translate (rise.normalized * curspeed * Time.deltaTime, Space.World);
				} else {
					if (curvalue != 0)
						hookrotate.totvalue += curvalue;
					curvalue = 0;
					AudioSource.PlayClipAtPoint (moneysound, transform.position);
					Destroy (gameObject);
					iscatch = false;
				}
//			Debug.Log (iscatch);
			} else {
				if (gameObject.tag == "wallet") {
				
					transform.Translate (initdirw * wallethrzspeed * Time.deltaTime, Space.World);
					if (transform.position.x < lbound && rightward == false) {
						initdirw = -initdirw;
						rightward = true;
					} else if (transform.position.x > rbound && rightward == true) {
						initdirw = -initdirw;
						rightward = false;
					}
				}
				if (gameObject.tag == "bill") {

					transform.Translate (initdirb * billvtcspeed * Time.deltaTime, Space.World);
					if (transform.position.y < bbound && upward == false) {
						initdirb = -initdirb;
						upward = true;
					} else if (transform.position.y > mtbound && upward == true) {
						initdirb = -initdirb;
						upward = false;
					}
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D target) {

		if (target.gameObject.tag == "hook" && h.pullback == false && h.isget == false) {
			//			if (soundEffect) {
			//				AudioSource.PlayClipAtPoint (soundEffect,transform.position);
			//			}
			//			Destroy (gameObject);
			iscatch = true;
//			Debug.Log (h.direction);
		}
	}
}
