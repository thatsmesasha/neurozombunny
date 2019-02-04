//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class PlayerHealth : MonoBehaviour
//{
//    public Image[] heartContainers;
//    public Sprite[] heartSprites;
    
//    public int currentHealth;
//    int maxHealth;
//    int healthPerHeart = 2;
//    int maxHearts = 3;

//    public bool damaged;
//    public Image damageImage;
//    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
//    public Color flashColour = new Color(0.8f, 0.25f, 0.29f, 0.2f);     // The colour the damageImage is set to, to flash.

//    bool isDead;                                                // Whether the player is dead.

    
//    // Start is called before the first frame update
//    void Start()
//    {
//        maxHealth = maxHearts * healthPerHeart;
//        currentHealth = maxHealth;
//    }

//    public void Heal(int amount)
//    {
//        currentHealth = Math.Min(currentHealth + amount, maxHealth);
//    }

//    public void TakeDamage(int amount)
//    {
//        currentHealth = Math.Max(currentHealth - amount, 0);
//        if (currentHealth == 0 && !isDead)
//        {
//            Debug.Log("GAME OVER :(");
//            // game over
//            Death();
//        }
//        damaged = true;
//    }

//    void Death ()
//    {
//        // Set the death flag so this function won't be called again.
//        isDead = true;

//        // Turn off any remaining shooting effects.
//        // playerShooting.DisableEffects ();

//        // Tell the animator that the player is dead.
//        // anim.SetTrigger ("Die");

//        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
//        // playerAudio.clip = deathClip;
//        // playerAudio.Play ();

//        // Turn off the movement and shooting scripts.
//        // playerMovement.enabled = false;
//        // playerShooting.enabled = false;
//    }

//    void updateHearts()
//    {
//        for (int i = 0; i < maxHearts; i++)
//        {
//            if (currentHealth <= i * healthPerHeart)
//            {
//                heartContainers[i].enabled = false;
//            }
//            else
//            {
//                heartContainers[i].enabled = true;
//                heartContainers[i].sprite = heartSprites[Math.Min(currentHealth - i * healthPerHeart, healthPerHeart) - 1];
//            }
//        }
//    }

//    void flashIfDamaged()
//    {
//        if (damaged)
//        {
//            // ... set the colour of the damageImage to the flash colour.
//            damageImage.color = flashColour;
//        }
//        // Otherwise...
//        else
//        {
//            // ... transition the colour back to clear.
//            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
//        }

//        // Reset the damaged flag.
//        damaged = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        updateHearts();
//        flashIfDamaged();
//    }
//}
