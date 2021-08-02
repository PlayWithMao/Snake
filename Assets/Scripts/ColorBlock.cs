using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    private ColorController colorController;
    private ColloringFood colloringFood;
    private Renderer renderer;
    private int colorsNumber;
    private int colorSnake;
    private int colorIndex;
    private bool change;

    private void Awake()
    {
        colorController = FindObjectOfType<ColorController>();
        colloringFood = FindObjectOfType<ColloringFood>();
        renderer = GetComponent<Renderer>();
    }
    private void Start()
    {
        colorsNumber = colorController.GetNumberColors();
        colorSnake = colorController.GetSnakeColor();

        ChangeColor();
    }

    private void ChangeColor()
    {
        colorIndex = Random.Range(0, colorsNumber);
        if (colorIndex == colorSnake) ChangeColor(); else UpdateColor();
    }

    private void UpdateColor()
    {
        renderer.material.color = colorController.GetColor(colorIndex);
        colloringFood.Colloring(colorIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material.color = renderer.material.color;
        if (!change)
        {
            colorController.SetSnakeColor(colorIndex);
            change = true;
        }
    }
}
