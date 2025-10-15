using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public Slider VolumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolume"))
            LoadVolume();
        else
        {
            PlayerPrefs.SetFloat("SoundVolume", 1);
            LoadVolume();

        }
    }


    public void SetVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("SoundVolume", VolumeSlider.value);
    }

    public void LoadVolume()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("SoundVolume");
    }

}
    
