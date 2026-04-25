using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public AudioSource backgroundMusicSource;

    private void Start()
    {
        float savedMaster = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);

        masterVolumeSlider.value = savedMaster;
        musicVolumeSlider.value = savedMusic;

        AudioListener.volume = savedMaster;

        if (backgroundMusicSource != null)
            backgroundMusicSource.volume = savedMusic;
    }

    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value)
    {
        if (backgroundMusicSource != null)
            backgroundMusicSource.volume = value;

        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }
}