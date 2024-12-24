using UnityEngine;
[AddComponentMenu("DangSon/ICanTakeDamage")]
public interface ICanTakeDamage 
{
    void TakeDamage(int damage, Vector2 fore, GameObject instigator);
}
