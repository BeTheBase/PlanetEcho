﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ruben
{
    public delegate void OnNoteBookKey();

    public class InputManager : MonoBehaviour
    {
        [Header("Controls")]
        [SerializeField] private string horizontalAxis;
        [SerializeField] private string verticalAxis;
        [SerializeField] private KeyCode rMouseButton, lMouseButton;
        public KeyCode jumpKey, crouchKey, runKey, notebookKey;

        public float hInput { get; private set; }
        public float vInput { get; private set; }

        public bool jumpKeyPressed { get; private set; } = false;
        public bool runKeyPressed { get; private set; } = false;
        public bool leftMouseButtonPressed { get; private set; } = false;
        public bool rightMouseButtonPressed { get; private set; } = false;

        public OnNoteBookKey onNoteBookKeyDel;

        //Singleton
        private static InputManager instance;
        public static InputManager Instance
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

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            hInput = Input.GetAxisRaw(horizontalAxis);
            vInput = Input.GetAxisRaw(verticalAxis);

            jumpKeyPressed = Input.GetKey(jumpKey);
            runKeyPressed = Input.GetKey(runKey);
            rightMouseButtonPressed = Input.GetKey(rMouseButton);
            leftMouseButtonPressed = Input.GetKey(lMouseButton);

            if (Input.GetKeyDown(notebookKey))
            {
                onNoteBookKeyDel?.Invoke();
            }
        }
    }
}
