using UnityEngine;
[CreateAssetMenu (menuName = "PowerUp/SpeedPickup")]
public class SpeedEffect : PowerUp_Effect
{
    public float SpeedNerf;

    public override void ApplyEffect(GameObject target)
    {
        target.GetComponent<PlayerController>().MoveForwardSpeed = SpeedNerf;
    }

    public override void DisableEffect(GameObject target)
    {
        target.GetComponent<PlayerController>().MoveForwardSpeed = 300;
    }

}
