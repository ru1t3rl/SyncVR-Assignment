﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Ru1t3rl
{
    public class CanvasManager : MonoBehaviour
    {
        [Header("Global")]
        [SerializeField] Canvas canvas;
        [SerializeField] TMP_InputField inputField;

        [Header("Visibility")]
        [SerializeField] GameObject emptyTextPrefab;
        [SerializeField] int maxVisibleNumbers;
        Queue<TextMeshProUGUI> visibleNumbers;
        Stack<TextMeshProUGUI> textObjects;

        [Header("Events")]
        [SerializeField] UnityEvent OnCorrect;
        [SerializeField] UnityEvent OnInCorrect;

        int currentIndex = 0;
        int currentNumber = 0;

        void Awake()
        {
            InstantiateTextObjects();
        }

        void InstantiateTextObjects()
        {
            visibleNumbers = new Queue<TextMeshProUGUI>();
            textObjects = new Stack<TextMeshProUGUI>();

            for (int i = 0; i < maxVisibleNumbers * 2; i++)
            {
                textObjects.Push(Instantiate(emptyTextPrefab, canvas.transform).GetComponent<TextMeshProUGUI>());
                textObjects.Peek().gameObject.SetActive(false);
            }
        }

        // Add the next number with an extra check. This could be used for quizes
        public void AddNextNumberWithCheck()
        {
            int answer = 0;
            System.Int32.TryParse(inputField.text, out answer);

            if (answer == System.Convert.ToInt32(Algorithms.Fibonacci(currentIndex)))
            {
                AddNextNumber(answer);
                OnCorrect?.Invoke();
            }
            else
            {
                OnInCorrect?.Invoke();
            }
        }

        /// <summary>
        /// Adds the next number in the fibonacci sequence to the screen
        /// 
        /// </summary>
        /// <param name="nextNum"></param>
        public void AddNextNumber(int nextNum = -1)
        {
            currentNumber = nextNum == -1 ? System.Convert.ToInt32(Algorithms.Fibonacci(currentIndex)) : nextNum;

            // Check if there are still objects in the pool or if the active objects has reached a max
            if (textObjects.Count == 0 || visibleNumbers.Count == maxVisibleNumbers)
            {
                visibleNumbers.Peek().gameObject.SetActive(false);
                textObjects.Push(visibleNumbers.Dequeue());
            }

            SetTextObject(textObjects.Pop());
            currentIndex++;
        }

        void SetTextObject(TextMeshProUGUI textMesh)
        {
            textMesh.text = currentNumber.ToString();
            textMesh.gameObject.name = $"FiboNum_{currentNumber}";
            textMesh.gameObject.SetActive(true);
            textMesh.transform.position = Vector3.zero;
            visibleNumbers.Enqueue(textMesh);
        }
    }
}
