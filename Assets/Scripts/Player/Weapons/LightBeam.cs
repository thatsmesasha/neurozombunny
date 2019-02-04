using EnemyHelper;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightBeam : MonoBehaviour, IWeapon
{
    public float damagePerShot = 1f;
    public float timeBetweenBullets = 0.15f;
    public EnemyType shootableEnemytype;

    public GameObject shootRay;

    float timer;
    readonly float effectsDisplayTime = 0.2f;

    GameObject shootingStart;
    GameObject shootingEnd;

    RaycastResult raycastResult;
    GvrControllerInputDevice inputDevice;

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
        if (inputDevice.GetButtonDown(GvrControllerButton.TouchPadButton) && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            shootRay.SetActive(false);
        }
    }

    void OnDisable()
    {
        shootRay.SetActive(false);
    }

    void Shoot()
    {
        timer = 0f;

        shootRay.SetActive(true);


        raycastResult = GvrPointerInputModule.CurrentRaycastResult;

        if (raycastResult.isValid)
        {
            EnemyHealth enemyHealth = raycastResult.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null && enemyHealth.type == shootableEnemytype)
            {
                enemyHealth.TakeDamage(damagePerShot, raycastResult.worldPosition);
            }
        }
        DisplayShootRay(shootingStart.transform.position, shootingEnd.transform.position, 0.03f);
    }

    void DisplayShootRay(Vector3 start, Vector3 end, float width)
    {
        Vector3 offset = end - start;
        Vector3 scale = new Vector3(width, offset.magnitude / 2f, width);
        Vector3 position = start + offset / 2f;
        shootRay.transform.up = offset;
        shootRay.transform.position = position;
        shootRay.transform.localScale = scale;
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
