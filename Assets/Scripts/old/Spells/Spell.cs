using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public string name;
    public float duration;
    public int damage;
    public GameObject shootingStart;
    public GameObject shootingEnd;

    float timer;
    protected GvrControllerInputDevice inputDevice = null;

    // Start is called before the first frame update
    protected void InitInputDevice()
    {
        inputDevice = GvrControllerInput.GetDevice(GvrControllerHand.Dominant);
    }

    protected bool IsActive()
    {
        return timer >= duration;
    }

    protected bool IsCasting()
    {
        return inputDevice.GetButtonDown(GvrControllerButton.TouchPadButton) && timer >= duration;
    }

    protected void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    protected void ResetTimer()
    {
        timer = 0f;
    }
}
