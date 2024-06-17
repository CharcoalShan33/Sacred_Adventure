using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{ 
    // makes this unable to be destroyed and a singleton
private static HealthManager _instance;
// for other variables to use
public static HealthManager Instance
{
    get
    {
        if (_instance == null)
            Debug.LogError("Instance Not Found!");
        return _instance;
    }
}


public Image healthBar, manaBar;


public float currentHealth, maxHealth, currentMana, maxMana;
public float healthRegen, manaRegen;

private void Awake()
{
    _instance = this;
}



// Start is called before the first frame update
void Start()
{
    currentHealth = 50f;
    maxHealth = 500f;
    currentMana = maxMana;
}

// Update is called once per frame
void Update()
{
    healthBar.fillAmount = Percentage();
    manaBar.fillAmount = ManaPercentage();
    Heal(healthRegen * Time.deltaTime);

    Rest(manaRegen * Time.deltaTime);


}
public void Heal(float num)
{
    currentHealth = Mathf.Min(currentHealth + num, maxHealth);
}

public void Rest(float manaAmount)
{
    currentMana = Mathf.Min(currentMana + manaAmount, maxMana);
}

public float Percentage()
{
    return currentHealth / maxHealth;
}
public float ManaPercentage()
{
    return currentMana / maxMana;
}

public void DamageTaken(float number)
{
    currentHealth = Mathf.Max(currentHealth - number, 0);
    if (currentHealth == 0)
    {
        Die();
    }
}

public void DecreaseMana(float usage)
{
    currentMana = Mathf.Max(currentMana - usage, 0f);
    if (currentMana <= 0f)
    {
        Rest(manaRegen);
    }
}

public void Die()
{
    Debug.Log("Dead");
}


}
