using Unity.VisualScripting;
using UnityEngine;



namespace Assets._Project.Features.MovementComponent
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour, IMovementable
    {
        //Internal States
        public bool isMoving { get; private set; }


        private Vector2 _dir;
        public float speed = 2.0f; //Descobrir como documentar variáveis
        public float maxAccelerationTime = 1.0f; //Descobrir como documentar variáveis
        public float totalAccelerationTime = 0.0f; //Descobrir como documentar variáveis
        public float frictionForce = 100.0f; //Descobrir como documentar variáveis

        //Component References
        private Rigidbody2D playerRb;

        public void Awake()
        {
            _dir = Vector2.zero;
            if (TryGetComponent<Rigidbody2D>(out var rb))
            {
                playerRb = rb;
            }
        }

        public void StartMovement(Vector2 dir)
        {
            _dir = dir;
            isMoving = true;
        }

        public void StopMovement(Vector2 dir)
        {
            _dir = dir;
            isMoving = false;
        }
        
        public void Update()
        {
            Debug.Log(_dir);
            if (Mathf.RoundToInt(totalAccelerationTime) < Mathf.RoundToInt(maxAccelerationTime))
            {
                totalAccelerationTime += Time.deltaTime;
            }
            //Move logic case
            if (isMoving && !_dir.IsUnityNull()) //Está se movendo e ganhando velocidade por X segundos.
            {
                var resultSpeed = new Vector2(_dir.x, Vector2.zero.y) * Time.deltaTime * speed;


                if (totalAccelerationTime < 1.0f)
                {
                    playerRb.linearVelocity = new Vector2(_dir.x, Vector2.zero.y) * 2;

                }
                else if (totalAccelerationTime < maxAccelerationTime)
                {
                    playerRb.linearVelocity += resultSpeed;

                }
                else if (totalAccelerationTime >= maxAccelerationTime)
                {
                    playerRb.linearVelocity = resultSpeed;
                }

            }
            else if (totalAccelerationTime > 0) //parou de se mover e perde aceleração progressivamente.
            {
                totalAccelerationTime -= Time.deltaTime * 2;
                if (totalAccelerationTime > 0.01f && totalAccelerationTime > -0.01f) //Se for tão pequeno, zera ele logo.
                {
                    totalAccelerationTime = 0.0f;
                }
            }
            //aplicar atrito
            if (_dir != Vector2.zero && !isMoving)
            {
                Vector2 friction = -_dir * Time.deltaTime * frictionForce;
                playerRb.linearVelocity += friction;

            }
        }
    }
}
