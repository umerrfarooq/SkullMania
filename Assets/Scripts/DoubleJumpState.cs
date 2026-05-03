using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleJumpState : PlayerBaseState
{
    public DoubleJumpState(PlayerStateMachine ctx, PlayerStateFactory factory) 
        : base(ctx, factory) { }
    
    public override void Enter()
    {
        // Apply double jump force
        ctx.rb.linearVelocity = new Vector2(ctx.rb.linearVelocity.x, ctx.jumpForce * ctx.doubleJumpMultiplier);
        ctx.canDoubleJump = false;
        
        // Update animations
        if (ctx.animator != null)
        {
            ctx.animator.SetTrigger("DoubleJump");
            ctx.animator.SetBool("IsJumping", true);
        }
        
        Debug.Log("Double Jump!");
    }
    
    public override void Update()
    {
        // Air control during double jump
        ctx.rb.linearVelocity = new Vector2(ctx.moveInput * ctx.speed, ctx.rb.linearVelocity.y);
        
        // Transition to falling
        if (ctx.rb.linearVelocity.y < 0)
        {
            ctx.ChangeState(factory.Falling());
        }
    }
    
    public override void Exit()
    {
        Debug.Log("Double jump complete");
    }
}