using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] internal float currenthealth;
    [SerializeField] internal float maxhealth;
    [SerializeField] internal float SliderPopupTime = 1f;
    [SerializeField] bool AlwaysShowHealthBar = false;
    [HideInInspector]
    public float Damagetaken;

    public Slider healthslider;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        if (healthslider != null)
        {
            SetupSlider();
        }
    }

    void SetupSlider()
    {
        healthslider.maxValue = maxhealth;
        healthslider.value = currenthealth;
        if(!AlwaysShowHealthBar) healthslider.gameObject.SetActive(false);
    }

    void UpdateSlider()
    {
        if (healthslider != null)
        {
            healthslider.value = currenthealth;
            if (!AlwaysShowHealthBar) StartCoroutine(PopupHealth());
        }
    }

    IEnumerator PopupHealth()
    {
        healthslider.gameObject.SetActive(true);
        yield return new WaitForSeconds(SliderPopupTime);
        healthslider.gameObject.SetActive(false);
    }

    public void GainHealth(float amount)
    {
        if (currenthealth < maxhealth && amount! > currenthealth - maxhealth)
        {
            currenthealth += amount;

        }
        else if (amount > currenthealth - maxhealth)
        {
            amount = currenthealth - maxhealth;
            currenthealth += amount;
        }
        UpdateSlider();
    }
    public void ReduceHealth(float amount)
    {
        Damagetaken = amount;
        if (currenthealth > 0 && amount < currenthealth)
        {
            currenthealth -= amount;
        }
        else if (amount >= currenthealth)
        {
            currenthealth = 0;
        }
        UpdateSlider();
    }
}
