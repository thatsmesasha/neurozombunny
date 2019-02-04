//using UnityEngine;
//using UnityEngine.EventSystems;
//using EnemyHelper;
//using System.Collections.Generic;

//public class PlayerShooting : MonoBehaviour
//{
//    public int damagePerShot = 1;
//    public float timeBetweenBullets = 0.15f;
//    public float range = 100f;

//    public GameObject shootRay;


//    float timer;
//    readonly float effectsDisplayTime = 0.2f;

//    GameObject shootingStart;
//    GameObject shootingEnd;

//    RaycastResult raycastResult;
//    GvrControllerInputDevice inputDevice;

//    public EnemyType currentEnemyType;

//    Dictionary<EnemyType, Color> enemyColors = new Dictionary<EnemyType, Color>()
//    {
//        [EnemyType.Pink] = new Color(0.96f, 0f, 0.71f),
//        [EnemyType.Blue] = new Color(0f, 0.91f, 0.93f),
//        [EnemyType.Yellow] = new Color(0.98f, 0.88f, 0f),
//    };

//    void Awake()
//    {
//        inputDevice = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);

//        shootingStart = GameObject.FindGameObjectWithTag("ShootingStart");
//        shootingEnd = GameObject.FindGameObjectWithTag("ShootingEnd");
//    }

//    void Update ()
//    {
//        timer += Time.deltaTime;

//        if (inputDevice.GetButtonDown(GvrControllerButton.TouchPadButton)
//            && timer >= timeBetweenBullets && System.Math.Abs(Time.timeScale) > 0.1)
//        {
//            switch (currentEnemyType)
//            {
//                case EnemyType.Yellow:
//                    //ShootYellow();
//                    break;

//                case EnemyType.Blue:
//                    //ShootBlue();
//                    break;

//                case EnemyType.Pink:
//                    ShootPink();
//                    break;

//                default:
//                    Debug.Log("Unknown current color");
//                    break;
//            }
//        }

//        if (timer >= timeBetweenBullets * effectsDisplayTime)
//        {
//            shootRay.SetActive(false);
//        }

//        UpdateSphereColor(enemyColors[currentEnemyType], timer >= timeBetweenBullets);
//    }


//    void UpdateSphereColor(Color color, bool enabled)
//    {
//        Material mat = GetComponent<Renderer>().material;

//        float emission = Mathf.PingPong(Time.time, 1.0f);
//        Color baseColor = enabled ? color : new Color(color.r * 0.5f, color.g * 0.5f, color.b * 0.5f);

//        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

//        mat.SetColor("_EmissionColor", finalColor);
//    }

//    void DisplayShootRay(Vector3 start, Vector3 end, float width)
//    {
//        Vector3 offset = end - start;
//        Vector3 scale = new Vector3(width, offset.magnitude / 2f, width);
//        Vector3 position = start + offset / 2f;
//        shootRay.transform.up = offset;
//        shootRay.transform.position = position;
//        shootRay.transform.localScale = scale;
//    }

//    GameObject Shoot(int damage)
//    {
//        timer = 0f;

//        raycastResult = GvrPointerInputModule.CurrentRaycastResult;

//        if (raycastResult.isValid)
//        {
//            EnemyHealth enemyHealth = raycastResult.gameObject.GetComponent<EnemyHealth>();
//            if (enemyHealth != null && enemyHealth.type == currentEnemyType)
//            {
//                enemyHealth.TakeDamage(damage, raycastResult.worldPosition);
//            }
//            return raycastResult.gameObject;
//        }
//        return null;
//    }


//    void ShootPink()
//    {
//        shootRay.SetActive(true);
//        Shoot(1);
//        DisplayShootRay(shootingStart.transform.position, shootingEnd.transform.position, 0.03f);
//    }
//}
