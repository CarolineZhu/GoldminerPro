using UnityEngine;
using System.Collections;

public class line : MonoBehaviour {


	private LineRenderer lineRenderer;
	private Vector3 start, end;
	public hookrotate h;

	// Use this for initialization
	void Start () {
		lineRenderer = gameObject.GetComponent<LineRenderer> ();
		lineRenderer.material = new Material(Shader.Find("Standard"));
		lineRenderer.SetColors(Color.black, Color.black); 
		lineRenderer.SetWidth(0.02f, 0.02f);
		start = h.gameObject.transform.position;
		start.z = -0.8f;
//		Debug.Log (start);
		lineRenderer.SetPosition(0, start);
	}

	// Update is called once per frame
	void Update () {
		lineRenderer = GetComponent<LineRenderer>();
		end = h.gameObject.transform.position;
		end.z = -0.8f;
//		Debug.Log (end);
		lineRenderer.SetPosition(1, end);
	}
}
