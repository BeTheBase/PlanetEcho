using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Ruben
{
    public class NoteBook : MonoBehaviour
    {
        [SerializeField] private float openingSpeed;
        [SerializeField] private Vector3 openedPosition, closedPosition;
        [SerializeField] private TextMeshProUGUI inputText;
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            inputText.enableWordWrapping = true;
        }

        private void Start()
        {
            InputManager.Instance.onNoteBookKeyDel += OpenNoteBook;
        }

        private void OnDisable()
        {
            InputManager.Instance.onNoteBookKeyDel -= OpenNoteBook;
            InputManager.Instance.onNoteBookKeyDel -= CloseNoteBook;
        }

        public void OpenNoteBook()
        {
            InputManager.Instance.onNoteBookKeyDel -= OpenNoteBook;
            InputManager.Instance.onNoteBookKeyDel += CloseNoteBook;

            StopAllCoroutines();

            MovementController.Instance.enabled = false;
            rectTransform.LerpRectTransform(this, openedPosition, openingSpeed);
        }

        public void CloseNoteBook()
        {
            InputManager.Instance.onNoteBookKeyDel -= CloseNoteBook;
            InputManager.Instance.onNoteBookKeyDel += OpenNoteBook;

            StopAllCoroutines();

            MovementController.Instance.enabled = true;
            rectTransform.LerpRectTransform(this, closedPosition, openingSpeed);
        }
    }
}
