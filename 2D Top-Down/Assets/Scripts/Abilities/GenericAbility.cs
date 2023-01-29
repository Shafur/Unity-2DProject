using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/GenericAbility", fileName = "NewGenericAbility")]

public class GenericAbility : ScriptableObject
{

    public float magicCost;
    public float duration;

    public FloatValue playerMagic;
    public Notification usePlayerMagic;
    

    
    public virtual void Ability(Vector2 playerPosition, Vector2 PlayerFacingDirection, Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {

    }
}
