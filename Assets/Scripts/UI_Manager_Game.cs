using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Manager_Game : MonoBehaviour
{
    TMP_Text lives;

    TMP_Text count;

    Image images;


    [Header("HP")]
    [SerializeField]
    TMP_Text maxText;
    [SerializeField]
    TMP_Text currentText;
    [Space]
    [Header("MP")]
    [SerializeField]
    TMP_Text maxManaText;
    [SerializeField]
    TMP_Text currentManaText;


    // Start is called before the first frame update
    void Start()
    {
        maxText.text = HealthManager.Instance.maxHealth.ToString();
        maxManaText.text = HealthManager.Instance.maxMana.ToString();
        lives.text = GameManager.instance.livesCount.ToString();
        count.text = GameManager.instance.enemyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth(HealthManager.Instance.currentHealth);
        UpdateMana(HealthManager.Instance.currentMana);
    }

    public void UpdateHealth(float amount)
    {

        currentText.text = amount.ToString("000");
        HealthManager.Instance.currentHealth = amount;

    }


    public void UpdateMana(float amount)
    {
        currentManaText.text = amount.ToString("000");
        HealthManager.Instance.currentMana = amount;
    }
}
