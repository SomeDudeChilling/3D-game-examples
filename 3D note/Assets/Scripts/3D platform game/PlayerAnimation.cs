using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnimation : MonoBehaviour
{
    private Movement _Movement;

    private Animator _PlayerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _Movement = GameObject.Find("Player").GetComponent<Movement>();
        _PlayerAnimator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            _PlayerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            _PlayerAnimator.SetBool("IsWalking", false);
        }

        if(_Movement.IsPlayerOnGround())
        {
            _PlayerAnimator.SetBool("IsOnGround", true);
        }
        else
        {
            _PlayerAnimator.SetBool("IsOnGround", false);
        }
    }
}
