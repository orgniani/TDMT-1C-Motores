using System.Collections;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthController enemyHP;

    [SerializeField] private CharacterMovement targetPosition;
    [SerializeField] private HealthController targetHP;

    private bool isShooting = true;
    [SerializeField] private float attackCooldown = 5f;

    private float distance;
    [SerializeField] private float startShootingDistance = 4f;

    private void Update()
    {
        if (!isShooting) return;

        distance = Vector2.Distance(transform.position, targetPosition.transform.position);

        if (targetHP.HP <= 0)
            return;

        if (attack == null)
        {
            Debug.LogError($"{name}: CharacterShooting is null!");
            return;
        }

        if (targetPosition == null)
            Debug.LogError($"{name}: Target is null!");

        else
        {
            Vector2 currentPosition = transform.position;
            Vector2 nextPosition = targetPosition.currentPosition;

            Vector2 directionToNextPos = nextPosition - currentPosition;

            if (distance < startShootingDistance)
                attack.Shoot(directionToNextPos);

            StartCoroutine(AttackSequence());
        }
    }

    private IEnumerator AttackSequence()
    {
        isShooting = false;

        yield return new WaitForSeconds(attackCooldown);

        isShooting = true;
    }
}
