using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    //Закрывает приложение
    public void CloseApp()
    {
        Application.Quit();
    }
}
