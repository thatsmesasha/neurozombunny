using UnityEngine;
using UnityEngine.EventSystems;
using EnemyHelper;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    public EnemyType currentEnemyType;
    public GameObject sphere;
    public GameObject[] weapons;
    public float changeSphereSpeed;
    public WeaponManager weaponManager;

    Dictionary<EnemyType, Color> enemyColors = new Dictionary<EnemyType, Color>()
    {
        [EnemyType.Pink] = new Color(0.96f, 0f, 0.71f),
        [EnemyType.Blue] = new Color(0f, 0.91f, 0.93f),
        [EnemyType.Yellow] = new Color(0.98f, 0.88f, 0f),
    };

    void Awake()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
    }

    void Update ()
    {
        currentEnemyType = GetCurrentWeapon();
        UpdateCurrentWeapon();
    }


    void UpdateSphereColor(Color color, bool available)
    {
        Material mat = sphere.GetComponent<Renderer>().material;

        Color baseColor = available ? color : new Color(color.r * 0.5f, color.g * 0.5f, color.b * 0.5f);

        Color finalColor = Color.Lerp(mat.GetColor("_EmissionColor"), baseColor, changeSphereSpeed * Time.deltaTime);

        mat.SetColor("_EmissionColor", finalColor);
    }

    EnemyType GetCurrentWeapon()
    {
        if (weaponManager && weaponManager.enabled)
        {
            return weaponManager.currentEnemyType;
        }
        return currentEnemyType;
    }

    void UpdateCurrentWeapon()
    {
        foreach (GameObject weapon in weapons)
        {
            IWeapon weaponObject = weapon.GetComponent<IWeapon>();
            if (weaponObject.GetShootableEnemyType() == currentEnemyType)
            {
                weapon.SetActive(true);
                UpdateSphereColor(enemyColors[currentEnemyType], weaponObject.IsAvailable());
            }
            else
            {
                weapon.SetActive(false);
            }
        }
    }

}
