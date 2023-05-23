using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private ScoreKeeper scoreKeeper;
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = healthSystem.GetHealth();
    }

    private void Update()
    {
        healthSlider.value = healthSystem.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");;
    }
}