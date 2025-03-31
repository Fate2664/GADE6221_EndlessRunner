using System.Collections;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public static bool PowerUpCheck = false;
    public float duration = 2f;
    private Coroutine activeRoutine;
    public PowerUp_Effect[] powerUps;
    public static string pickup;
    private void Update()
    {
        if (PowerUpCheck && activeRoutine == null)
        {
            activeRoutine = StartCoroutine(PickupRoutine());
        }
    }

    public IEnumerator PickupRoutine()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float setTime = 0f;

        while (setTime < duration)
        {
            setTime += Time.deltaTime;
            switch (pickup)
            {
                case "SpeedPickup":
                    powerUps[0].ApplyEffect(player); break;

            }
            yield return null;
        }
        DeactivateEffect(player);
        activeRoutine = null;
    }

    public void DeactivateEffect(GameObject player)
    {
        switch (pickup)
        {
            case "SpeedPickup":
                powerUps[0].DisableEffect(player); break;
        }
        PowerUpCheck = false;
    }

    
}
