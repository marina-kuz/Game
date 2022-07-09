using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Класс игрока, управляемого человеком
//игрок двигается на клавиши WASD и поворачивается в заисимости от направления мышки
//стреляет при нажатии на левую кнопку мышки
public class Player : Characters
{
    [Header("Значения игрока")]
    //скорость персонажа
    public float speed=3f;
    [Header("Значения пули")]
    //начальная точка выстрела
    public Transform bulletPoint;
    //префаб пули
    public GameObject bulletPrefab;
    [Header("Всплывающее окно")]
    //переменная для вывода сообщений о действиях персонажа
    public NoteScr note;

    private Camera camera;
    private Rigidbody2D rb;

    //движение в зависимости от нажатых клавиш
    private Vector2 movement;
    //позиция мышки
    private Vector2 mousePos;
    //направление персонажа
    private Vector2 lookDirect;
    //угол преследуемого объекта по отношению к персонажу
    private float angle;

    void Start()
    {
        //переменные из родительского класса
        heart=6;//здоровье/сердечки
        //пока что персонаж жив
        isAlive=true;

        rb=this.GetComponent<Rigidbody2D>();
        camera=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        //задаем движение игрока
        movement=new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        mousePos=camera.ScreenToWorldPoint(Input.mousePosition);
        //если нажата ЛКМ, то стреляем из точки(bulletPoint) пулей(bulletPrefab)
        if(Input.GetMouseButtonDown(0))
        {
            Shoot(bulletPoint,bulletPrefab,0.3f);
            SetNote("Пиф-паф!");
        }
        if(!isAlive)
        {
           FinishPanel("Вы умерли! :(");
        }
    }

    void FixedUpdate()
    {
        //движение по указанному направлению и разварот по направлению к мышки
        rb.MovePosition(rb.position+movement.normalized*speed*Time.fixedDeltaTime);
        lookDirect=mousePos-rb.position;
        angle=Mathf.Atan2(lookDirect.y,lookDirect.x)*Mathf.Rad2Deg-90f;
        rb.rotation=angle;
    }

    //Объявляет сообщение о действиях персонажа
    public void SetNote(string str)
    {
        note.SetTemporaryNote(str);
    }
}
