using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponentInChildren<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
         
    }

    public void Jump(bool jump)
    {
        _animator.SetBool("Jump", jump);
    }
}
