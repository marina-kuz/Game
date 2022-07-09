using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс пули
public class Bullet : MonoBehaviour
{
    //переменная для подсчета столкновений
    private int shot=0;

    void OnCollisionEnter2D(Collision2D coll)
    {
        shot++;
        //пуля попала во врага или героя
        if(coll.gameObject.CompareTag("Enemy")||coll.gameObject.CompareTag("Player"))
        {
            //уничтожаем пулю
            Destroy(gameObject);
            //если попала в героя, то увеличиваем очки врагу, уменьшаем здоровье игроку
            // и выводим надпись
            if(coll.gameObject.CompareTag("Player"))
            {
                coll.gameObject.GetComponent<Player>().SetDamage(false);
                coll.gameObject.GetComponent<Player>().SetNote("Ауч! Попал!");
            }
            else if((coll.gameObject.CompareTag("Enemy")))
            {
                coll.gameObject.GetComponent<Enemy>().SetDamage(true);
            }
            //при столкновении с границами экрана пуля удаляется
            else
            {
                Destroy(gameObject);
            }
        }
        //если столкновений больше 4, то пуля удаляется
        if(shot>4)
        {
            Destroy(gameObject);
        }
    }
}
