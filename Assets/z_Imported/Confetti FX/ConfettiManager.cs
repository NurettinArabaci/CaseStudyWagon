using UnityEngine;

public partial class EventManager
{

    public static event System.Action OnConfettiPlay;
    public static void Fire_OnConfettiPlay() { OnConfettiPlay?.Invoke(); }

}
public class ConfettiManager : MonoBehaviour
{
    ParticleSystem _particleSystem;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();

        EventManager.OnConfettiPlay += OnConfettiPlay;
    }

    void OnConfettiPlay()
    {
        _particleSystem.Play();
    }

    private void OnDisable()
    {
        EventManager.OnConfettiPlay -= OnConfettiPlay;
    }
}
