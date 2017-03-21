using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEditor;
using UnityEngine.SceneManagement;
//using System.Windows.Forms;
//using System.Deployment;

public class scorer : MonoBehaviour {

	// Use this for initialization
//	public static int currentscore = 0;
//	public hookrotate h;
	public Text Scoretext;
	public Text Leveltext;
	public Text Goaltext;
	public int curLevel;
	public timer t;
	private int[] aimScore = {1500, 3500, 6000};
	private bool issuccess = true;
	public Texture2D rstbtn, extbtn, ctnbtn, boxbg;
	public AudioClip[] levelsound;
//	public MessageBoxButtons buttons;


	void Start () {
		curLevel = UnityEngine.Application.loadedLevel;
		AudioSource.PlayClipAtPoint (levelsound[curLevel - 1],transform.position);
		Leveltext.text = "Level" + Mathf.Round(curLevel).ToString();
		Goaltext.text = "Goal: " + Mathf.Round(aimScore[curLevel - 1]).ToString();
	}
	
	// Update is called once per frame
	void Update () {
//		currentscore = hookrotate.totvalue;
//		curLevel = UnityEngine.Application.loadedLevel;
		Scoretext.text = "Score: " + Mathf.Round(hookrotate.totvalue).ToString();
		if (t.gameInProgress == false) {
			if (hookrotate.totvalue < aimScore [curLevel - 1]) {
				issuccess = false;

			} else {
					issuccess = true; 
			}

		}
	}
	void OnGUI(){
		if (t.gameInProgress == false) {
			GUIStyle fontStyle = new GUIStyle();
			fontStyle.normal.textColor = Color.white;
			fontStyle.normal.background = boxbg;
			fontStyle.fontSize = 20; 
			if (issuccess == false) {
				GUI.Box (new Rect (300, 150, 400, 150), "       Sorry, do not reach current goal.", fontStyle);
				if (GUI.Button (new Rect (550, 200, 100, 60), rstbtn)) {
					SceneManager.LoadScene (0);
					hookrotate.totvalue = 0;
				}
				if (GUI.Button (new Rect (350, 200, 100, 60), extbtn))
					UnityEngine.Application.Quit ();
			} else {
				if (curLevel < 3) {
					GUI.Box (new Rect (300, 150, 400, 150), "           Reach current goal! Go on!", fontStyle);
					if (GUI.Button (new Rect (550, 200, 100, 60), ctnbtn)) {
						SceneManager.LoadScene (curLevel + 1);
					}
					if (GUI.Button (new Rect (350, 200, 100, 60), extbtn)) {  
						UnityEngine.Application.Quit ();
					}
				} else {
					GUI.Box (new Rect (300, 150, 400, 150), "       Reach the final! Congratulations!", fontStyle);
					if (GUI.Button (new Rect (550, 200, 100, 60), rstbtn)) {
						SceneManager.LoadScene (0);
					}
					if (GUI.Button (new Rect (350, 200, 100, 60), extbtn)) {  
						UnityEngine.Application.Quit ();
					}
				}
			}
		
		}
	
	}
}
