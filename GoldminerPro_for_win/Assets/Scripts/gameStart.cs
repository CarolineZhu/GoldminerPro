using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour {

	// Use this for initialization
	public Texture2D img;
	public AudioClip menusound;
	void Start () {
		AudioSource.PlayClipAtPoint (menusound,transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnGUI()  
	{  
		GUIStyle fontStyle = new GUIStyle();
		fontStyle.normal.textColor = Color.white;
		fontStyle.normal.background = img;
		fontStyle.fontSize = 50; 
		if(GUI.Button (new Rect (600, 240, 170, 70), "  start", fontStyle))
			SceneManager.LoadScene("level1");
		
//		GUI.Label (new Rect (100, 100, miner2.width/4, texture.height/4), cover/miner2);

	}  
}
