using UnityEngine;

public class Salut : MonoBehaviour
{
    public static Salut instance { get; private set; }

    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private int _numberDecorationToys = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateActiveDecorationToys()
    {
        _numberDecorationToys--;

        if (0 == _numberDecorationToys)
            PlayAllParticleSystems();
    }

    private void PlayAllParticleSystems()
    {
        foreach (var particleSystem in _particleSystems)
        {
            particleSystem.Play();
        }
    }
}
