using UnityEngine;

public class Combo : MonoBehaviour
{
    [Range(2, 5)] [SerializeField] private int speed;
    [Range(3, 5)] [SerializeField] private int time;

    private InputController inputController;
    private Snake snake;
    private CrystalBank crystalBank;

    private bool isCombo;
    private float miliSecond;
    private float second;

    private void Awake()
    {
        inputController = FindObjectOfType<InputController>();
        snake = FindObjectOfType<Snake>();
        crystalBank = FindObjectOfType<CrystalBank>();
    }

    private void Update()
    {
        if (isCombo)
        {
            if (transform.position.x != 0)
            {
                TransformCenter();
            }

            miliSecond += 0.02f;
            if (miliSecond >= 1)
            {
                second++;
                miliSecond = 0;
                print(second);
                if (second >= time) ActivatedCombo(false);
            }
        }
    }

    public void ActivatedCombo(bool status)
    {
        miliSecond = 0;
        second = 0;

        isCombo = status;
        inputController.BlockController(status);

        if (status)
        {
            snake.SetSpeedCombo(speed);
        }
        else
        {
            snake.SetSpeedCombo(1);
            crystalBank.ResetCrystals();
        } 
    }

    private void TransformCenter()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.05f);
    }

    public bool GetStatus()
    {
        return isCombo;
    }
}
