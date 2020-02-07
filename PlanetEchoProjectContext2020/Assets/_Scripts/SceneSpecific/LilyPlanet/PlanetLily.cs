using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Ruben
{
    public class PlanetLily : MonoBehaviour
    {
        public UnityEvent OnLimitReached;
        public int maxWooshiesSpawned = 0;
        [Range(0, 1f)]
        public float maxDestroyedPercent = 0.2f;
        private float destroyedPercentage 
        { get 
            { 
                return ((float)destroyedWooshies / (float)maxWooshiesSpawned); 
            } 
            set 
            { 
            } 
        }
        private int destroyedWooshies = 0;
        [SerializeField] private string text = "";
        [SerializeField] private TextMeshProUGUI wooshieText;

        //Singleton
        private static PlanetLily instance;
        public static PlanetLily Instance
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

        public void AddDestroyedWooshie()
        {
            if (!LimitReached())
            {
                destroyedWooshies += 1;
                UpdateUiText();
            }
        }

        public void AddSpawnedWooshie()
        {
            maxWooshiesSpawned += 1;
            UpdateUiText();
        }

        private void UpdateUiText()
        {
            wooshieText.text = text + "(" + (int)(destroyedPercentage * 100) + "/" + maxDestroyedPercent * 100 + ")";
        }

        private bool LimitReached()
        {
            if (destroyedPercentage >= maxDestroyedPercent)
            {
                OnLimitReached?.Invoke();
                return true;
            }
            return false;
        }

        
    }
}
