using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets._Project.Features.MovementComponent;
using Assets._Project.Features.JumpComponent;

namespace Assets._Project.Features.InputComponent
{
    [RequireComponent(typeof(Movement), typeof(Jump))]
    public class Input : MonoBehaviour
    {
        [SerializeField] private Movement movementComponent;   
        [SerializeField] private Jump jumpComponent;
        public void Awake()
        {
            if (movementComponent.IsUnityNull()) throw new ArgumentNullException($"movement Null reference in {name}");
        }
        //Input Actions
        private InputAction move;
        private InputAction jump;
        private void Start()
        {
            move = InputSystem.actions.FindAction("Move");
            move.performed += MoveIn; //event in
            move.canceled += MoveOut; //event out

            jump = InputSystem.actions.FindAction("Jump");
            jump.performed += JumpIn;

        }

        private void MoveIn(InputAction.CallbackContext context)
        {
            var dir = context.ReadValue<Vector2>();
            movementComponent.StartMovement(dir);

        }
        private void MoveOut(InputAction.CallbackContext context)
        {
            var dir = context.ReadValue<Vector2>();
            movementComponent.StopMovement(dir);
        }


        private void JumpIn(InputAction.CallbackContext context)
        {
            jumpComponent.StartJump();

        }

    }

}
