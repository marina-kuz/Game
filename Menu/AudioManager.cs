using UnityEngine;
using UnityEngine.UI;
//Класс отвечает за настройку музыки
public class AudioManager : MonoBehaviour
{
    //Название данных для PlayerPrefs
    private static readonly string FirstPlay="FirstPlay";
    private static readonly string SoundPref="SoundPref";
    //переменная для того чтобы узнать игрок вперые зашел в игру или нет
    private int firstPlay;
    //громкость звука
    private float sound;
    public Slider soundSlider;
    public AudioSource audio;

    void Start()
    {
        firstPlay=PlayerPrefs.GetInt(FirstPlay);
        //Пользователь впервые открыл игру
        if(firstPlay==0)
        {
            //Делаем звук 50% и сохраняем в PlayerPrefs
            sound=.50f;
            soundSlider.value=sound;
            PlayerPrefs.SetFloat(SoundPref,sound);
            PlayerPrefs.SetInt(FirstPlay,-1);
        }
        else
        {
            //Задаем сохраненные значения музыки
            sound=PlayerPrefs.GetFloat(SoundPref);
            soundSlider.value=sound;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(SoundPref,soundSlider.value);
    }
    //Сохраняем значение звука, когда игрок выходит из игры
    void OnApplicationFocus(bool focusStatus)
    {
        if(!focusStatus)
        {
            SaveSoundSettings();
        }
    }
    public void UpdateSound()
    {
        audio.volume=soundSlider.value;
    }
}
