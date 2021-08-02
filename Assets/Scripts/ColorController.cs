using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] Color[] colors;

    private int colorIndexSnake;

    public Color GetColor(int index)
    {
        return colors[index];
    }

    public int GetNumberColors()
    {
        return colors.Length;
    }

    public void SetSnakeColor(int index)
    {
        colorIndexSnake = index;
    }

    public int GetSnakeColor()
    {
        return colorIndexSnake;
    }
}
