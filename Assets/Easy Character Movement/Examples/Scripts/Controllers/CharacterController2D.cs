﻿using System;
using ECM.Controllers;
using UnityEngine;

namespace ECM.Examples
{
    /// <summary>
    /// This shows how to extend BaseCharacterController to perform common 2D constrained movement.
    /// </summary>

    public class CharacterController2D : BaseCharacterController
    {

        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        /// <summary>
        /// Overrides BaseCharacterController Animate method.
        /// </summary>

        protected override void Animate()
        {
            _animator.SetFloat("Speed",movement.forwardSpeed);
        }

        

        /// <summary>
        /// Overrides BaseCharacterController HandleInput method. 
        /// </summary>

        protected override void HandleInput()
        {
            // Toggle pause / resume.
            // By default, will restore character's velocity on resume (eg: restoreVelocityOnResume = true)

            if (Input.GetKeyDown(KeyCode.P))
                pause = !pause;

            // Handle input, Here we allow horizontal movement only

            moveDirection = new Vector3
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = 0.0f,
                z = 0.0f
            };

            jump = Input.GetButton("Jump");

            crouch = Input.GetKey(KeyCode.C);
            
        }

        /// <summary>
        /// Overrides BaseCharacterController HandleInput method. 
        /// </summary>

        protected override void UpdateRotation()
        {
            // Rotate towards movement direction (input), in this case left / right.

            // Here we update character rotation to change direction instead of smoothly rotate to new direction

            if (moveDirection.sqrMagnitude > 0.0001f)
                movement.rotation = Quaternion.LookRotation(moveDirection);
        }

        /// <summary>
        /// Overrides BaseCharacterController Awake method. 
        /// </summary>

        public override void Awake()
        {
            // Initialize BaseCharacterController

            base.Awake();

            // Disable movement in Z to force 2D motion (X / Y) only.

            var rb = GetComponent<Rigidbody>();
            if (rb)
                rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }

        public override void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y);
            base.Update();
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movement.Dash();
            }
        }
        
    }
}
