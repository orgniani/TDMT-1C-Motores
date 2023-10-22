using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource deadSoundEffect;

    [SerializeField] private CharacterShooting attack;
    [SerializeField] private HealthPoints hurtAndDead;

    private void OnEnable()
    {
        attack.onShoot += HandleShoot;
        hurtAndDead.onHurt += HandleHurt;
        hurtAndDead.onDead += HandleDead;
    }

    private void OnDisable()
    {
        attack.onShoot -= HandleShoot;
        hurtAndDead.onHurt -= HandleHurt;
        hurtAndDead.onDead -= HandleDead;
    }

    private void HandleShoot()
    {
        shootSoundEffect.Play();
    }

    private void HandleHurt()
    {
        hurtSoundEffect.Play();
    }

    private void HandleDead()
    {
        deadSoundEffect.Play();
    }
}
