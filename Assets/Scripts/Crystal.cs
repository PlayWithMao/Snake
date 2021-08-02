using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour
{
    [Range(0.05f, 0.1f)] [SerializeField] private float speed;
    [SerializeField] private int number;

    private CrystalBank crystalBank;
    private bool isTransform;
    private Transform snake;
    private void Awake()
    {
        crystalBank = FindObjectOfType<CrystalBank>();
    }

    private void Update()
    {
        if (isTransform)
        {
            TransformFood();
            StartCoroutine(DeleteFood());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Head")
        {
            snake = other.transform;
            isTransform = true;
        }
    }

    private void TransformFood()
    {
        transform.position = Vector3.MoveTowards(transform.position, snake.position, speed);
    }

    private IEnumerator DeleteFood()
    {
        yield return new WaitForSeconds(speed);

        crystalBank.AddCrystal(number);
        Destroy(gameObject);
    }
}
