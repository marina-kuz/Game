using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//родительский класс для дочерних классов: Enemy, Player
//Enemy игрок, управляемый компьютером
//Player игрок, управляемый человеком
public class Characters : MonoBehaviour
{
    //здоровье персонажа
    protected int heart;
    //жив ли он
    protected bool isAlive;
    //переменная для вывода очков
    public ScoreScr score;
    //панель, на которой сказано кто победил
    public GameObject panel;
    //для подсчета времени через которое можно опять стрелять
    private float timeBtwShots;

    protected void Start()
    {
        score=gameObject.GetComponent<ScoreScr>();
        panel=gameObject.GetComponent<GameObject>();
    }
    //урон 
    public void SetDamage(bool toEnemy)
    {
        heart-=1;
        if(heart<=0)
        {
            isAlive=false;
        }
        //если попали во врага
        if(toEnemy==true)
        {
            //увеличиваем очки игроку
            score.SetScoreToPlayer();
        }
        else
        {
            score.SetScoreToEnemy();
        }
    }
    //Метод выстрела
    //bulletPoint - начальная точка выстрела
    //bulletPrefab - префаб пули
    //startShots - через сколько секунд можно выстрелить пулю повторно
    protected void Shoot(Transform bulletPoint,GameObject bulletPrefab, float startShots)
    {
        if(timeBtwShots<=0)
        {
            //создаем пулю и задаем ей движение
            GameObject bullet_ =Instantiate(bulletPrefab,bulletPoint.position,bulletPoint.rotation);
            Rigidbody2D rb_ =bullet_.GetComponent<Rigidbody2D>();
            rb_.AddForce(bulletPoint.up*10f,ForceMode2D.Impulse);
            timeBtwShots=startShots;
        }
        else{
            timeBtwShots-=Time.deltaTime;
        }
    }
    //метод вызывает панель на которой сказано кто победил
    protected void FinishPanel(string str)
    {
        panel.gameObject.SetActive(true);
        panel.transform.GetChild(0).GetComponent<Text>().text=str;
        //пауза игры
        Time.timeScale = 0;
    }
}