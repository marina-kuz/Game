using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс игрока, управляемого компьютером - враг
public class Enemy : Characters
{
    [Header("Значения врага")]
    //скорость персонажа
    public float speed=2f;
    [Header("Значения пули")]
    //начальная точка выстрела
    public Transform bulletPoint;
    //префаб пули
    public GameObject bulletPrefab;
    [Header("Игрок")]
    //игрок
    public GameObject player;

    //дистанция на которой враг должен остановиться перед игроком
    private float distance=1.2f;
    //направление персонажа
    private Vector2 lookDirect;
    //угол преследуемого объекта по отношению к персонажу
    private float angle;
    //угол смещения движения при столкновении с препядствиями
    private float offset=45f;
    RaycastHit2D hit;
    //слой на котором лежат препядствия
    private LayerMask barrierLayer;
    //длина на которую отбрасывется луч в слое препядствий
    private float barrierRay=1f;
    //слой на котором лежит игрок
    private LayerMask playerLayer;

    private Rigidbody2D rb;

    void Start()
    {
        //переменные из родительского класса
        heart=6;
        //пока что враг жив
        isAlive=true;
        rb=GetComponent<Rigidbody2D>();
        barrierLayer = LayerMask.GetMask("Barrier");
        playerLayer=LayerMask.GetMask("Player");
    }

    void Update()
    {
        if(!isAlive)
        {
           FinishPanel("Вы победили! :)");
        }
    }

    void FixedUpdate()
    {        
        //определям направление "взгляда" по отношению к игроку
        lookDirect=(Vector2)player.transform.position-rb.position;
        //переводим это значение в градусы
        angle=Mathf.Atan2(lookDirect.y,lookDirect.x)*Mathf.Rad2Deg-90f;
        
        //проверяем встречается ли враг со стеной
        hit=Physics2D.Raycast(transform.position, lookDirect, barrierRay,barrierLayer);
        if(hit.collider != null)
        {
            //меняем угол движения
            angle=angle+offset;
            //назначаем угол движения врага
            rb.rotation=angle;
            transform.position=Vector2.MoveTowards(transform.position, bulletPoint.position,speed*Time.fixedDeltaTime);
        }
        else
        {
            //назначаем угол движения врага
            rb.rotation=angle;
            //если расстояние до игрока больше distance, то двигаемся на него
            if(Vector2.Distance(transform.position,player.transform.position)>=distance)
            {
                //движение и разворот по направлению к игроку
                transform.position=Vector2.MoveTowards(transform.position, player.transform.position,speed*Time.fixedDeltaTime);
            }
            //прицеливание
            //если луч видит игрока, то происходит выстрел
            hit=Physics2D.Raycast(transform.position, lookDirect, 3f,playerLayer);
            if(hit.collider != null)
            {
                Shoot(bulletPoint,bulletPrefab,0.8f);
            }
        }
    }
}
