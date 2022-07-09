using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Класс отвечает за всплывающее окно с надписями от игрока
public class NoteScr : MonoBehaviour
{
    public GameObject panel;
    private Text note;
    //время через которое окно "закроется"
    private float tick=5.0f;

    void Start()
    {
        //Делаем панель не активной
        panel.SetActive(false);
        //Берем компонент Text из первого(и единственного) ребенка панели
        note=GetComponent<Text>();
    }
    //устанавливаем note текст и начинаем корутин,
    //который ненадолго покажет установленный текст
    public void SetTemporaryNote(string str)
    {
        panel.SetActive(true);
        note.text=str;
        StartCoroutine(TempNote());
    }

    IEnumerator TempNote()
    {
        yield return new WaitForSeconds(tick);
        panel.SetActive(false);
    }
}
