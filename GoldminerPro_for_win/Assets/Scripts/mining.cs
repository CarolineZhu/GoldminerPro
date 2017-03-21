using UnityEngine;
using System.Collections;
using System.Threading;


public class mining : MonoBehaviour {

	private Animator an;
	public hookrotate h;


	// Use this for initialization
	void Start () {
		an = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (h.isget == true)
			an.SetInteger("charstate", 1);
		else
			an.SetInteger("charstate", 0);

	}
}
