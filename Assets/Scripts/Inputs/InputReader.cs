using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterShooting attack;

    [SerializeField] private EnemiesManager enemies;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        if (!characterMovement)
            return;

        //TODO: TP2 - Fix - Enabling movement based on HP should be handled by the character, not the input class --> DONE
        Vector2 inputValue = inputContext.ReadValue<Vector2>();
        characterMovement.SetDirection(inputValue);
    }

    public void Shoot(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            if (attack == null)
            {
                Debug.LogError($"{name}: CharacterShooting is null!");
                return;
            }

            attack.Shoot(characterMovement.lastDirection);
        }
    }

    public void DamageAllEnemiesCheat(InputAction.CallbackContext inputContext)
    {
        if(enemies == null)
        {
            Debug.LogError($"{name}: EnemiesManager is null!");
            return;
        }

        enemies.DamageAllEnemies();
    }
}