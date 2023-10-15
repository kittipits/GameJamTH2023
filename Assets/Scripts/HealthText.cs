using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private PlayerHealth targetHealth;
    [SerializeField] private Text hp_text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hp_text.text = (targetHealth.currentHealth * 100 / targetHealth.maxHealth).ToString() + "%";

    }
}
