using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public enum ViewType
    {
        Normal = 0,
        Crouched = 1
    }
    public class CameraController : MonoBehaviour
    {
        public View[] views;

        public float xSensitivity = 15f;
        public float ySensitivity = 15f;

        public float minYRot = -60f;
        public float maxYRot = 60f;

        public float minXRot = 0;
        public float maxXRot = 360;

        private float yRotation = 0f;
        private float xRotation = 0f;

        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Rigidbody rb;

        private void OnEnable()
        {
            MovementController mCont = MovementController.Instance;

            mCont.StartCrouchDel += SetView;
            mCont.ExitCrouchDel += SetView;
        }

        private void OnDisable()
        {
            MovementController mCont = MovementController.Instance;
            if (mCont != null)
            {
                mCont.StartCrouchDel -= SetView;
                mCont.ExitCrouchDel -= SetView;
            }
        }

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            //Horizontal Rotation
            transform.Rotate(0, Input.GetAxis("Mouse X") * xSensitivity, 0);

            //Vertical Rotation
            yRotation += -(Input.GetAxis("Mouse Y") * ySensitivity);
            yRotation = Mathf.Clamp(yRotation, minYRot, maxYRot);
            cameraTransform.localEulerAngles = new Vector3(yRotation, 0, cameraTransform.localEulerAngles.z);
        }

        private void SetView(ViewType viewType = ViewType.Normal)
        {
            View wView = System.Array.Find(views, (x) => x.viewType == viewType);

            if (wView.position != Vector3.zero)
            {
                cameraTransform.localPosition = wView.position;
            }

            cameraTransform.localEulerAngles = new Vector3(cameraTransform.localEulerAngles.x, wView.rotation.y, wView.rotation.z);
        }
    }
}
