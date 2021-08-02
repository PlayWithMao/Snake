using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CrystalBank : MonoBehaviour
{
    [SerializeField] private Text tCrystal;
    [Range(0, 1)] [SerializeField] private float timer;
    [Range(3, 5)] [SerializeField] private int crystalsForCombo;

    private Combo combo;
    private int crystal;
    private int crystalUp;
    private int successivelyCrystals;

    private void Awake()
    {
        combo = FindObjectOfType<Combo>();
    }


    public void AddCrystal(int value)
    {
        crystalUp += value;
        StartCoroutine(SmoothChange(crystal, crystalUp, timer));
    }

    private IEnumerator SmoothChange(float from, float to, float timer)
    {
        float t = 0.0f;
        float value = from;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (1.0f / timer);
            value = (int)Mathf.Lerp(from, to, t);

            crystal = Mathf.RoundToInt(value);
            UpdateText();
            yield return 0;
        }
        CheckCombo(); 
    }

    private void CheckCombo()
    {
        if (!combo.GetStatus())
        {
            successivelyCrystals++;
            if (successivelyCrystals == crystalsForCombo)
            {
                StartCombo();
            }
        }
    }

    private void StartCombo()
    {
        combo.ActivatedCombo(true);
    }

    public void ResetCrystals()
    {
        successivelyCrystals = 0;
        crystal = 0;
        crystalUp = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        tCrystal.text = "+" + crystal;
    }
}
