using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Animator PlayerAnimation;
    
	void Start ()
    {
        PlayerAnimation = GetComponent<Animator>();
	}
	
	void Update ()
    {	
        if (Input.GetKeyDown("a"))
        {
            PlayerAnimation.Play("Right", -1, 0f);
        }
        if (Input.GetKeyDown("d"))
        {
            PlayerAnimation.Play("Left", -1, 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnimation.Play("Walking", -1, 0f);
        }
        if (Input.GetKeyDown("s"))
        {
            PlayerAnimation.Play("Sitting", -1, 0f);
        }
    }
}
