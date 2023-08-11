using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public GameObject menu; //меню которое скрывает кнопка, важно чтоб при запуске сцены была активна
    public Toggle hideElement; //верхний элемент, который убирает ставит все чекбоксы какие есть
    public GameObject hideCube; //элемент, который регулирует прозрачность одного из кубов создается автоматом
    public Toggle unActiveElements; //элемент включающимй отключающий все обьекты
    public Slider transparencySlider; // слайдер прозрачности общий
    public GameObject[] cubes; //массив кубов
    public GameObject[] hideCubesElement; //массив элементов отвечающих за параметры куба
    // Start is called before the first frame update
    void Start()
    {
        cubes = GameObject.FindGameObjectsWithTag("Object"); //находим все кубы
        foreach (var o in cubes)
        {
            GameObject g = Instantiate(hideCube, menu.transform, false);//привязываем обьекты к меню
            g.name= o.name;
        }
        hideCubesElement = GameObject.FindGameObjectsWithTag("hideCubesElement"); //находим все обьекты регулировки
       
    }
    // Update is called once per frame
    void Update()
    {
        SetUnActiveOnce();
        
    }
 

        public void CheckCubes()//включает отключает все чекбоксы
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (hideCubesElement[i].transform.Find("hideCube").GetComponent<Toggle>().isOn)
            {
                hideCubesElement[i].transform.Find("hideCube").GetComponent<Toggle>().isOn = false;
            }
            else
            {
                hideCubesElement[i].transform.Find("hideCube").GetComponent<Toggle>().isOn = true;
            }
        }
    }
 
    public void SetUnActiveCubes()//отключает кубы
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (unActiveElements.isOn && hideCubesElement[i].transform.Find("hideCube").GetComponent<Toggle>().isOn)
            {
                hideCubesElement[i].transform.Find("VisibleCube").GetComponent<Toggle>().isOn = true;
            }
            if (!unActiveElements.isOn && hideCubesElement[i].transform.Find("hideCube").GetComponent<Toggle>().isOn)
            {
                hideCubesElement[i].transform.Find("VisibleCube").GetComponent<Toggle>().isOn = false;
            }
        }
           
    }
    public void SetUnActiveOnce() // отключает конкретный куб
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (hideCubesElement[i].transform.Find("VisibleCube").GetComponent<Toggle>().isOn)
            {
                cubes[i].SetActive(true);
                
            }
            else
            {
                cubes[i].SetActive(false);
            }

        }

        for(int i = 0; i < cubes.Length; i++) // а тут внезапно изменение прозрачности конкретного куба
        {
                        Color col = cubes[i].GetComponent<Renderer>().material.color;
                        col.a = hideCubesElement[i].transform.Find("SliderCube").GetComponent<Slider>().value; // pass float value here
                        cubes[i].GetComponent<Renderer>().material.color = col;
        }
    }
    public void TransparencyCubes()//прозрачность общая
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (hideCubesElement[i].transform.Find("hideCube").GetComponent<Toggle>().isOn)
            {
                Color col = cubes[i].GetComponent<Renderer>().material.color;
                hideCubesElement[i].transform.Find("SliderCube").GetComponent<Slider>().value = transparencySlider.value; // pass float value here
                cubes[i].GetComponent<Renderer>().material.color = col;
            }
            
        }
    }
    public void VisibilityCubes()//видимость общая
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            if (hideCubesElement[i].transform.Find("hideCube").GetComponent<Toggle>().isOn)
            {
                Color col = cubes[i].GetComponent<Renderer>().material.color;
                hideCubesElement[i].transform.Find("SliderCube").GetComponent<Slider>().value = transparencySlider.value; // pass float value here
                cubes[i].GetComponent<Renderer>().material.color = col;
            }

        }
    }
    public void HideMenuButton()// скрыть меню 
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
}
