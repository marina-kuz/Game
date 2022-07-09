using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//класс увеличивает количество очков
//и вызывает метод для смены спрайта сердечка
public class ScoreScr : MonoBehaviour
{
    public HealthScr heart;
    int score_hero, score_enemy;
    void Start()
    {
        score_enemy=0;
        score_hero=0;
    }
    public void SetScoreToPlayer()
    {
        score_hero+=1;
        this.GetComponent<Text>().text=score_hero+":"+score_enemy;
    }
    public void SetScoreToEnemy()
    {
        score_enemy+=1;
        this.GetComponent<Text>().text=score_hero+":"+score_enemy;
        heart.ChangeHeart();
    }
    public string GetScore()
    {
        return this.GetComponent<Text>().text;
    }
}
