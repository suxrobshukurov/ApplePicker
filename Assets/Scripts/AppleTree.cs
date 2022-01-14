using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set Inspector")]
    // шаблон для создания яблок
    public GameObject applePrefab;

    // скорость движение яблони
    public float speed = 10f;

    // растояние на которое должно изменяться направление движения яблони
    public float leftAndRightEdge = 20f;

    //Вероятность случайного изменения направления движения
    public float changeToChangeDirections = 0.02f;

    // частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;

    private void Start()
    {
        // сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

    private void Update()
    {
        // простое перемешение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // изменение направления
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        } 
    }

    private void FixedUpdate()
    {
        if (Random.value < changeToChangeDirections)
        {
            speed *= -1; // меняем направление движения 
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
}
