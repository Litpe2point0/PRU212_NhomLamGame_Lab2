using UnityEngine;

public class SpecialEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;
    public void PlayEffect()
    {
        particleSystem.Play();
    }
}
