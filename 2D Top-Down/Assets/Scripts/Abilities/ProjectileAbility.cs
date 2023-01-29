using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/ProjectileAbility", fileName = "NewProjectileAbility")]

public class ProjectileAbility : GenericAbility
{
    [SerializeField]
    private GameObject thisProjectile;

    public override void Ability(Vector2 playerPosition, Vector2 PlayerFacingDirection, Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        float facingRotation = Mathf.Atan2(PlayerFacingDirection.y, PlayerFacingDirection.x);

        GameObject newProjectile = Instantiate(thisProjectile, playerPosition, Quaternion.Euler(0f, facingRotation, 0f));
    }
}
