using UnityEngine;
using System.Collections.Generic;
using EnemyHelper;
using UnityEngine.EventSystems;

public class FireSpirit : MonoBehaviour, IWeapon
{
    public float timeBetweenBullets = 0.5f;
    public EnemyType shootableEnemytype;

    //Ray shootRay;
    //RaycastHit shootHit;

    GameObject shootingStart;
    GameObject shootingEnd;
    public GameObject fireSpitirInstance;

    GvrControllerInputDevice inputDevice;

    float timer;


    void Awake()
    {
        inputDevice = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);

        shootingStart = GameObject.FindGameObjectWithTag("ShootingStart");
        shootingEnd = GameObject.FindGameObjectWithTag("ShootingEnd");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (inputDevice.GetButton(GvrControllerButton.TouchPadButton) && timer >= timeBetweenBullets)
        {
            DisplayFireBeam();
        }
    }

    void DisplayFireBeam()
    {
        timer = 0f;
        GameObject beam = Instantiate(fireSpitirInstance,
            shootingStart.transform.position + shootingStart.transform.forward / 3f,
            Quaternion.LookRotation((shootingEnd.transform.position - 
                shootingStart.transform.position)));
        beam.SetActive(true);
    }

    public bool IsAvailable()
    {
        return timer >= timeBetweenBullets;
    }

    public EnemyType GetShootableEnemyType()
    {
        return shootableEnemytype;
    }
}
