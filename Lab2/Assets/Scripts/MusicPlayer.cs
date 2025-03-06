using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioSource> sfxSource;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumneKey = "SFXVolume";

    private void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumneKey, 1f);
        musicSource.volume = savedMusicVolume;
        musicSlider.value = savedMusicVolume;
        foreach (var source in sfxSource)
        {
            source.volume = savedSFXVolume;
        }
        sfxSlider.value = savedSFXVolume;

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }
    public void SetSFXVolume(float volume)
    {
        foreach (var source in sfxSource)
        {
            source.volume = volume;
        }
        PlayerPrefs.SetFloat(SFXVolumneKey, volume);
        PlayerPrefs.Save();
    }
}

