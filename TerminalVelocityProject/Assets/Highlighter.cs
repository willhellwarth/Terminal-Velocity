using UnityEngine;
using System.Collections;

public class Highlighter : MonoBehaviour {

	private HighlightableObject myHo;
	public Color highlightColor;
	// Use this for initialization
	void Start () {
		myHo =  gameObject.AddComponent<HighlightableObject> ();
		myHo.ConstantOn (highlightColor);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
