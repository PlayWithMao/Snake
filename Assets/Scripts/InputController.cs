using UnityEngine;

public class InputController : MonoBehaviour
{
    [Range(0, 0.1f)] [SerializeField] private float speed;

    private RaycastHit hit;
    private bool isBlock;
    private void Update()
    {
        if (!isBlock)
        {
            Vector3 point = new Vector3(hit.point.x, transform.position.y, transform.position.z);

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    transform.position = Vector3.MoveTowards(transform.position, point, speed);
                }
            }
        }
    }

    public void BlockController(bool status)
    {
        isBlock = status;
    }
}
