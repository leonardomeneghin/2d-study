using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Entities;
using UnityEngine;

namespace Assets._Project.Features.JumpComponent
{
    /*
     Melhoria: quando jump sofrer modificações maiores, adicionar o padrão State, para trocar de estados isJumping e isGrounded
     */
    [RequireComponent(typeof(Rigidbody2D))]
    internal class Jump : MonoBehaviour, IJumpable
    {
        public float jumpForce = 2.0f; //Descobrir como documentar variáveis
        public float fallMultiplier = 1.0f; //Descobrir como documentar variáveis
        public float lowJumpMultiplier = 2.0f; //Descobrir como documentar variáveis
        //Component References
        private Rigidbody2D playerRb;

        public bool isJumping { get; private set; }
        public bool isGrounded { get; private set; }

        public void Awake()
        {
            if(TryGetComponent<Rigidbody2D>(out var rb)){
                playerRb = rb;
            }

        }
        public void StartJump()
        {
            isJumping = true;
            if (!isGrounded) return;
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
        }

        public void Update()
        {
            if (playerRb.linearVelocity.y < 0) //Caindo
            {
                playerRb.linearVelocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (playerRb.linearVelocity.y > 0 && isJumping) //player subindo, mas soltaram o botão
            {
                playerRb.linearVelocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
