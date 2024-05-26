using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 10;
    private int currentHP;

    public TextMeshProUGUI playerHPText;
    public GameManager gameManager;

    private bool isInvincible = false;

    void Awake()
    {
        ResetHP();
    }

    private void Update()
    {
        playerHPText.text = "HP: " + currentHP.ToString() + " / " + maxHP.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHP -= damage;
            if (currentHP <= 0)
            {
                currentHP = 0;
                gameManager.GameOver();

            }
            else
            {
                StartCoroutine(Invincibility());
            }
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(2f);
        isInvincible = false;
    }

    public void ResetHP()
    {
        currentHP = maxHP;
    }
}
