using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
    [Header("Set Dinamically")]
    public Text scoreGT;

    private void Start()
    {
        //GameObject scoreGT = GetComponent<Text>();
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        Scene scene = SceneManager.GetActiveScene();
        scoreGT.text = "0";



    }
    private void Update()
    {
        // получаем текушие координанты указателя мыши на экран из Input
        Vector3 mousePos2D = Input.mousePosition;

        // координата z камеры определяет как далеко в трехмерном пространстве находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        // преобразовывем точку нв двумерной плоскости экрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // перемешение корзины вдоль оси X в координате X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // отыскать яблоко, попавшее в эту корзину
        GameObject collidedWidth = collision.gameObject;
        if (collidedWidth.tag == "Apple")
        {
            Destroy(collidedWidth);
        }

        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();


        if (score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
