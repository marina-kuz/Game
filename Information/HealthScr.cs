using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс меняет спраты сердец
public class HealthScr : MonoBehaviour
{
    //перменная для подсчета сердца, которое еще не использовалось(не меняло спрайт)
    private int h=0;
    private List<GameObject> hearts=new List<GameObject>();
    public Sprite emptyHeart;
    public Sprite halfHeart;
    private bool heartEnd;

    void Start()
    {
        //собираем всех детей элемента в список
        foreach (Transform child in this.transform) {
            hearts.Add(child.gameObject);
        }
        heartEnd=false;
    }

    public void ChangeHeart()
    {
        if(heartEnd)
        {
            //устанавливаем нужному сердечку спрайт с пустым сердцем
            hearts[h].GetComponent<SpriteRenderer>().sprite=emptyHeart;
            h++;
            heartEnd=false;
        }
        else{
            //либо пол сердца
            hearts[h].GetComponent<SpriteRenderer>().sprite=halfHeart;
            heartEnd=true;
        }
    }
}
