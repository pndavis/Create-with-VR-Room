using UnityEngine;

/// <summary>
/// Toggles particle system
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class ToggleParticle : MonoBehaviour
{
    private ParticleSystem currentParticleSystem = null;
    private MonoBehaviour currentOwner = null;
    private AudioSource sound = null;

    private void Awake()
    {
        currentParticleSystem = GetComponent<ParticleSystem>();
        sound = GetComponent<AudioSource>();
    }

    public void Play()
    {
        currentParticleSystem.Play();
    }

    public void Stop()
    {
        currentParticleSystem.Stop();
    }
    public void Flip()
    {
        if (currentParticleSystem.isEmitting)
        {
            currentParticleSystem.Stop();
            sound.Stop();
        }
        else
        {
            currentParticleSystem.Play();
            sound.Play();
        }
    }

    public void PlayWithExclusivity(MonoBehaviour owner)
    {
        if(currentOwner == null)
        {
            currentOwner = this;
            Play();
        }
    }

    public void StopWithExclusivity(MonoBehaviour owner)
    {
        if(currentOwner == this)
        {
            currentOwner = null;
            Stop();
        }
    }

    private void OnValidate()
    {
        if(currentParticleSystem)
        {
            ParticleSystem.MainModule main = currentParticleSystem.main;
            main.playOnAwake = false;
        }
    }
}
