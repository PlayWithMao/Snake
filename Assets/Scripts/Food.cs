using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour
{
    [Range(0.05f, 0.1f)] [SerializeField] private float speed;

    private bool isTransform;
    private Transform snake;
    private Combo combo;

    private void Awake()
    {
        combo = FindObjectOfType<Combo>();
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
            if (other.GetComponent<Renderer>().material.color == GetComponent<Renderer>().material.color || combo.GetStatus())
            {
                snake = other.transform;
                isTransform = true;
            }
            else RestartLevel();
        }
    }

    private void TransformFood()
    {
        transform.position = Vector3.MoveTowards(transform.position, snake.position, speed);
    }

    private IEnumerator DeleteFood()
    {
        yield return new WaitForSeconds(speed);
        Destroy(gameObject);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
