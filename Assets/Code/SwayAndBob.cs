using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Player
{
    public class SwayAndBob : MonoBehaviour
    {
        public PlayerMovement playerMovement;
        private Rigidbody rb;
        private PlayerInputActions playerInputActions;

        [Header("Sway")]
        public bool cameraSwayEnabled;
        public float testFloat;
        public float step = 0.01f;
        public float maxStepDistance = 0.06f;
        Vector3 swayPos;

        [Header("Sway Rotation")]
        public float rotationStep = 4f;
        public float maxRotationStep = 5f;
        Vector3 swayEulerRot;

        public float smooth = 10f;
        float smoothRot = 12f;

        [Header("Bobbing")]
        public float speedCurve;
        float curveSin { get => Mathf.Sin(speedCurve); }
        float curveCos { get => Mathf.Cos(speedCurve); }

        public Vector3 travelLimit = Vector3.one * 0.025f;
        public Vector3 bobLimit = Vector3.one * 0.01f;
        Vector3 bobPosition;

        public float bobExaggeration;

        [Header("Bob Rotation")]
        public Vector3 multiplier;
        Vector3 bobEulerRotation;

        // Start is called before the first frame update
        void Start()
        {
            rb = playerMovement.GetComponent<Rigidbody>();
            playerInputActions = GameManager.Instance.playerInputActions;
        }

        // Update is called once per frame
        void Update()
        {
            GetInput();

            Sway();
            SwayRotation();
            BobOffset();
            BobRotation();

            CompositePositionRotation();
        }


        Vector2 walkInput;
        Vector2 lookInput;

        void GetInput()
        {
            walkInput.x = Input.GetAxis("Horizontal");
            walkInput.y = Input.GetAxis("Vertical");
            walkInput = walkInput.normalized;

            if (!cameraSwayEnabled) return;
            lookInput.x = playerInputActions.Night.Look.ReadValue<Vector2>().x;
            lookInput.y = -playerInputActions.Night.Look.ReadValue<Vector2>().y;
        }


        void Sway()
        {
            Vector3 invertLook = lookInput * -step;
            invertLook.x = Mathf.Clamp(invertLook.x, -maxStepDistance, maxStepDistance);
            invertLook.y = Mathf.Clamp(invertLook.y, -maxStepDistance, maxStepDistance);

            swayPos = invertLook;
        }

        void SwayRotation()
        {
            Vector2 invertLook = lookInput * -rotationStep;
            invertLook.x = Mathf.Clamp(invertLook.x, -maxRotationStep, maxRotationStep);
            invertLook.y = Mathf.Clamp(invertLook.y, -maxRotationStep, maxRotationStep);
            swayEulerRot = new Vector3(invertLook.y, invertLook.x, invertLook.x);
        }

        void CompositePositionRotation()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, swayPos + bobPosition, Time.deltaTime * smooth);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(swayEulerRot) * Quaternion.Euler(bobEulerRotation), Time.deltaTime * smoothRot);
        }

        void BobOffset()
        {
            speedCurve += Time.deltaTime * rb.velocity.magnitude * bobExaggeration + 0.01f;

            bobPosition.x = (curveCos * bobLimit.x) - (walkInput.x * travelLimit.x);
            bobPosition.y = (curveSin * bobLimit.y) - (rb.velocity.y * travelLimit.y);
            bobPosition.z = -(walkInput.y * travelLimit.z * rb.velocity.magnitude / 12);
        }

        void BobRotation()
        {
            bobEulerRotation.x = (walkInput != Vector2.zero ? multiplier.x * (Mathf.Sin(2 * speedCurve)) : multiplier.x * (Mathf.Sin(2 * speedCurve) / 2));
            bobEulerRotation.y = (walkInput != Vector2.zero ? multiplier.y * curveCos : 0);
            bobEulerRotation.z = (walkInput != Vector2.zero ? multiplier.z * curveCos * walkInput.x : 0);
        }

    }
}
