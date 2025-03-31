using UnityEngine;

public abstract class PowerUp_Effect : ScriptableObject
{
    public abstract void ApplyEffect(GameObject target);

    public abstract void DisableEffect(GameObject target);
}
