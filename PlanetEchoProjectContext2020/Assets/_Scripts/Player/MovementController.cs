using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public delegate void OnStartCrouch(ViewType view);
    public delegate void OnExitCrouch(ViewType view);
    public class MovementController : MonoBehaviour
    {
        [Header("Stats")]
        public float walkSpeed = 10f;
        public float crouchSpeed = 6f;
        public float airSpeed = 4f;
        [Range(0, 3)]
        public float runSpeedAmplifier = 1.5f;

        [Space()]
        public float groundJumpVel = 10f;
        private float normalHeight;
        public float crouchHeight = 1.3f;

        [Space()]
        public float gravityAmplifier = 2f;
        public float groundCollisionAngle = 15f;

        private InputManager input;

        //Move bools
        private bool isTouchingGround = true;

        private bool isRunning = false;
        private bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (value)
                {
                    walkSpeed *= runSpeedAmplifier;
                } else
                {
                    walkSpeed /= runSpeedAmplifier;
                }
                isRunning = value;
            }
        }

        private bool isCrouching = false;
        private bool IsCrouching
        {
            get { return isCrouching; }
            set
            {
                if (value != isCrouching)
                {
                    if (value)
                    {
                        StartCrouchDel?.Invoke(ViewType.Crouched);
                    } else
                    {
                        ExitCrouchDel?.Invoke(ViewType.Normal);
                    }
                }
                isCrouching = value;
            }
        }

        //Delegates
        public OnStartCrouch StartCrouchDel;
        public OnExitCrouch ExitCrouchDel;

        [Header("Components")]
        //Components
        [SerializeField] private Rigidbody rb;
        [SerializeField] private CapsuleCollider col;

        //Singleton
        private static MovementController instance;
        public static MovementController Instance
        {
            get { return instance; }
            private set { instance = value; }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            } else
            {
                Destroy(gameObject);
            }
        }

        //#region OnEnableDisable

        //private void OnEnable()
        //{
        //    StartCrouchDel += Crouch;
        //    ExitCrouchDel += Crouch;
        //}

        //private void OnDisable()
        //{
        //    StartCrouchDel -= Crouch;
        //    ExitCrouchDel -= Crouch;
        //}
        //#endregion

        private void Start()
        {
            input = InputManager.Instance;
        }

        private void FixedUpdate()
        {
            if (isTouchingGround)
            {
                GroundMovement();
            } else
            {
                AirMovement();
            }

            CustomGravity();
        }

        private void CustomGravity()
        {
            rb.velocity -= transform.up * gravityAmplifier;
        }


        #region MovementFunctions
        private void AirMovement()
        {
            Vector3 moveVelocity = Vector3.zero;
            moveVelocity += (transform.right * input.hInput) * airSpeed;
            moveVelocity += (transform.forward * input.vInput) * airSpeed;
            moveVelocity.y = rb.velocity.y;

            rb.velocity = moveVelocity;

            isCrouching = false;
        }

        private void GroundMovement()
        {
            Vector3 moveVelocity = Vector3.zero;
            moveVelocity += transform.right * input.hInput;
            moveVelocity += transform.forward * input.vInput;
            moveVelocity = moveVelocity.normalized;
            moveVelocity *= walkSpeed;

            rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

            if (input.jumpKeyPressed)
            {
                GroundJump();
            }

            //IsCrouching = wantToCrouch;
        }

        private void GroundJump()
        {
            rb.AddForce(transform.up * groundJumpVel, ForceMode.Impulse);
        }

        //private void CrouchMovement()
        //{
        //    Vector3 moveVelocity = Vector3.zero;
        //    if (rb.velocity.x + rb.velocity.z < crouchSpeed + 2 && rb.velocity.x + rb.velocity.z > -(crouchSpeed + 2))
        //    {
        //        moveVelocity += transform.right * input.hInput;
        //        moveVelocity += transform.forward * input.vInput;
        //        moveVelocity = moveVelocity.normalized;
        //        moveVelocity *= crouchSpeed;
        //    } else
        //    {
        //        moveVelocity = rb.velocity - transform.forward;
        //    }

        //    rb.velocity = moveVelocity;

        //    isCrouching = input.;

        //    if (wantToJump)
        //    {
        //        GroundJump();
        //    }

        //}

        //private void Crouch(ViewType view)
        //{
        //    float heightDif = normalHeight - crouchHeight;
        //    col.height = (view == ViewType.Crouched) ? crouchHeight : normalHeight;

        //    Vector3 colCenter = col.center;
        //    colCenter.y += (view == ViewType.Crouched) ? heightDif * -0.5f : heightDif * 0.5f;
        //    col.center = colCenter;
        //}

        #endregion

        #region CollisionHandling

        private void OnCollisionEnter(Collision collision)
        {
            List<ContactPoint> contactPoints = new List<ContactPoint>();
            collision.GetContacts(contactPoints);
            CheckOnCollisionHits(contactPoints);
        }

        private void OnCollisionExit(Collision collision)
        {
            isTouchingGround = false;
        }

        private void CheckOnCollisionHits(List<ContactPoint> contactPoints)
        {
            for (int i = 0; i < contactPoints.Count; i++)
            {
                if (contactPoints[i].otherCollider == null) break;

                Vector3 dir = contactPoints[i].normal;

                //Ground
                if (Vector3.Angle(dir, Vector3.up) <= groundCollisionAngle && Vector3.Angle(dir, Vector3.up) >= -groundCollisionAngle)
                {
                    isTouchingGround = true;
                    return;
                }

            }
            isTouchingGround = false;
        }
        #endregion
    }
}
