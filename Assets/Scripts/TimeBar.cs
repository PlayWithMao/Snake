using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private Image iTimeBar;
    [Range(30, 60)] [SerializeField] private int time;

    private float miliSecond;
    private float second;

    private void FixedUpdate()
    {
        miliSecond += 0.02f;
        if (miliSecond >= 1)
        {
            second++;
            miliSecond = 0;

            if (second >= time) RestartLevel(); else UpdateBar();
        }
    }

    private void UpdateBar()
    {
        iTimeBar.fillAmount = (time - second) / time;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
