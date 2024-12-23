using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider sliderMusic;         // Slider untuk mengubah volume
    public AudioSource sumberSuara;    // AudioSource untuk memutar musik
    public float volume = 1;           // Volume default
    public const string keyVolume = "VOLUME";  // Key untuk menyimpan volume di PlayerPrefs

    private void Start()
    {
        // Periksa apakah slider dan AudioSource terhubung dengan benar
        if (sliderMusic == null)
        {
            Debug.LogError("SliderMusic tidak terhubung! Pastikan Slider telah diassign di Inspector.");
            return;
        }

        if (sumberSuara == null)
        {
            Debug.LogError("SumberSuara tidak terhubung! Pastikan AudioSource telah diassign di Inspector.");
            return;
        }

        // Cek apakah volume sudah disimpan di PlayerPrefs, jika tidak, set ke volume default (1)
        if (PlayerPrefs.HasKey(keyVolume))
        {
            float volumeTerakhir = PlayerPrefs.GetFloat(keyVolume);
            KetikaSliderDiubah(volumeTerakhir);  // Set volume pada AudioSource
            sliderMusic.value = volumeTerakhir;  // Set nilai slider sesuai dengan volume yang disimpan
        }
        else
        {
            // Jika volume belum disimpan, set nilai default
            PlayerPrefs.SetFloat(keyVolume, 1f); // Menyimpan nilai default 1 (maksimal)
            sliderMusic.value = 1f;              // Set slider ke volume maksimal
            KetikaSliderDiubah(1f);              // Set AudioSource volume ke 1 (maksimal)
        }
    }

    public void KetikaSliderDiubah(float nilaiSlider)
    {
        volume = nilaiSlider;                // Menyimpan nilai volume yang baru
        sumberSuara.volume = nilaiSlider;     // Mengatur volume AudioSource

        PlayerPrefs.SetFloat(keyVolume, nilaiSlider);  // Menyimpan nilai volume ke PlayerPrefs
    }
}
