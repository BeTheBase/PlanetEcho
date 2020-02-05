using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public class HeadBob : MonoBehaviour
    {

        public float bobbingSpeed = 0.18f;
        public float bobbingAmount = 0.2f;
        public float midpoint = 2.0f;
        public float count = 0;

        private float timer = 0.0f;
        private float waveslice;

        private Vector3 cSharpConversion;
        private InputManager input;

        private void Start()
        {
            input = InputManager.Instance;
            midpoint = transform.localPosition.y;
        }

        void Update()
        {
            waveslice = 0.0f;

            cSharpConversion = transform.localPosition;

            if (Mathf.Abs(input.hInput) == 0 && Mathf.Abs(input.vInput) == 0)
            {
                timer = 0.0f;
            } else
            {
                waveslice = Mathf.Sin(timer);
                timer = timer + bobbingSpeed;
                if (timer > Mathf.PI * 2)
                {
                    timer = timer - (Mathf.PI * 2);
                }
            }
            if (waveslice != 0)
            {
                float translateChange = waveslice * bobbingAmount;
                float totalAxes = Mathf.Abs(input.hInput) + Mathf.Abs(input.vInput);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                cSharpConversion.y = midpoint + translateChange;
            } else
            {
                cSharpConversion.y = midpoint;
            }
            transform.localPosition = cSharpConversion;
        }
    }
}
