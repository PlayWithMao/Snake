using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColloringFood : MonoBehaviour
{
    [SerializeField] private GameObject[] foods;

    private ColorController colorController;
    private int colorsNumber;
    private int colorIndex;
    private Color[] colorsFood = new Color[2];

    private void Awake()
    {
        colorController = FindObjectOfType<ColorController>();
    }

    private void Start()
    {
        colorsNumber = colorController.GetNumberColors();
    }

    private void ChangeColor(int index)
    {
        colorIndex = Random.Range(0, colorsNumber);
        if (colorIndex == index) ChangeColor(index); else UpdateColor(index);
    }

    private void UpdateColor(int index)
    {
        colorsFood[0] = colorController.GetColor(index);
        colorsFood[1] = colorController.GetColor(colorIndex);
    }

    public void Colloring(int index)
    {
        ChangeColor(index);

        int value = Random.Range(0, colorsFood.Length);
        foreach (var food in foods)
        {
            var objs = food.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].material.color = colorsFood[value];
            }
            if (value == 0) value++; else value = 0;
        }
    }
}
