using UnityEngine;

/// <summary>
/// GameビューにてSceneビューのようなカメラの動きをマウス操作によって実現する
/// </summary>
[RequireComponent(typeof(Camera))]
public class SceneViewCamera : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)]
    private float wheelSpeed = 1f;

    [SerializeField, Range(0.1f, 10f)]
    private float moveSpeed = 0.3f;

    [SerializeField, Range(0.1f, 10f)]
    private float rotateSpeed = 0.3f;
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private GameObject startObj;
    private Vector3 preMousePos;
    private void Start()
    {
        transform.position = startObj.transform.position;
    }
    private void Update()
    {
        MouseUpdate();
        Move();
        if (Input.GetKey(KeyCode.Space)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                transform.position -= new Vector3(0, 0.02f, 0);
            }
            else
            {
                transform.position += new Vector3(0,0.02f,0);
            }
        }
        return;
    }
    private void Move()
    {
        // WASDで移動する
        float x = 0.0f;
        float z = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            x += 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            z += 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z -= 1.0f;
        }
        var muki = transform.forward * z + transform.right * x;
        transform.position += new Vector3(muki.x,0,muki.z).normalized*Time.deltaTime*MoveSpeed;
    }
    private void MouseUpdate()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0f)
            MouseWheel(scrollWheel);

        if (Input.GetMouseButtonDown(0) ||
           Input.GetMouseButtonDown(1) ||
           Input.GetMouseButtonDown(2))
            preMousePos = Input.mousePosition;

        MouseDrag(Input.mousePosition);
    }

    private void MouseWheel(float delta)
    {
        var f = transform.forward;
        transform.position +=new Vector3(f.x,0,f.z)  * delta * wheelSpeed;
        return;
    }

    private void MouseDrag(Vector3 mousePos)
    {
        Vector3 diff = mousePos - preMousePos;

        if (diff.magnitude < Vector3.kEpsilon)
            return;

        if (Input.GetMouseButton(2))
            transform.Translate(-diff * Time.deltaTime * moveSpeed);
        else if (Input.GetMouseButton(1))
            CameraRotate(new Vector2(-diff.y, diff.x) * rotateSpeed);

        preMousePos = mousePos;
    }

    public void CameraRotate(Vector2 angle)
    {
        transform.RotateAround(transform.position, transform.right, angle.x);
        transform.RotateAround(transform.position, Vector3.up, angle.y);
    }
}