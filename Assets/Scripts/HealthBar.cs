using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth targetHealth;
    [SerializeField] private Image hp_frame;
    [SerializeField] private Image hp_amount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        hp_amount.fillAmount = targetHealth.currentHealth / targetHealth.maxHealth;
    } 
}
