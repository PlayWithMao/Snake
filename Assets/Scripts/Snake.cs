using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private ColorController colorController;
    [SerializeField] private List<Transform> tails;
    [Range(0, 3)] [SerializeField] private float boneDistance;
    [Range(0, 0.1f)] [SerializeField] private float speed;

    private int speedCombo;

    private void Awake()
    {
        speedCombo = 1;
    }

    private void Start()
    {
        SnakeStartColor();
        BonesInStartPosition();
    }

    private void FixedUpdate()
    {
        MoveSnake();
    }

    private void BonesInStartPosition()
    {
        foreach (var bone in tails)
        {
            bone.position = transform.position;
        }
    }

    private void SnakeStartColor()
    {
        Color startColor = colorController.GetColor(0);

        GetComponent<Renderer>().material.color = startColor;
        foreach (var bone in tails)
        {
            bone.GetComponent<Renderer>().material.color = startColor;
        }

        colorController.SetSnakeColor(0);
    }

    private void MoveSnake()
    {
        MoveBone();
        transform.position = transform.position + transform.forward * speed * speedCombo;
    }

    private void MoveBone()
    {
        float sqrDistance = boneDistance * boneDistance;
        Vector3 prevPosition = transform.position;

        foreach (var bone in tails)
        {
            if ((bone.position - prevPosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = prevPosition;
                prevPosition = temp;
            }
            else
            {
                break;
            }
        }
    }

    public void SetSpeedCombo(int value)
    {
        speedCombo = value;
    }
}
