using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    [Range(0.05f, 0.1f)] [SerializeField] private float speed;

    private Combo combo;
    private bool isTransform;
    private Transform snake;

    private void Awake()
    {
        combo = FindObjectOfType<Combo>();
    }

    private void Update()
    {
        if (isTransform)
        {
            TransformBlock();
            StartCoroutine(DeleteBlock());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Head")
        {
            if (combo.GetStatus())
            {
                snake = other.transform;
                isTransform = true;
            }
            else
            {
                RestartLevel();
            }
        }
    }

    private void TransformBlock()
    {
        transform.position = Vector3.MoveTowards(transform.position, snake.position, speed);
    }

    private IEnumerator DeleteBlock()
    {
        yield return new WaitForSeconds(speed);
        Destroy(gameObject);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
