using UnityEngine;
public class HumanWalk : MonoBehaviour {
    [SerializeField]
    private float Speed;
    public float JumpHeight;
    public float RotateSpeed;
    private bool Moving;
    private float kyori;
    public float kakusokudo;
    private void FixedUpdate()
    {
        int a = 0;
        if (Input.GetKey(KeyCode.W)) {
            a++;
        }
        if (Input.GetKey(KeyCode.S)) {
            a--;
        }
        Moving = a != 0;
        int b=0;
        if (Input.GetKey(KeyCode.D)) {
            b++;
        }
        if (Input.GetKey(KeyCode.A)) {
            b--;
        }

        var forward= a*transform.forward * Time.deltaTime * Speed;
        if (Moving)
        {
            kyori += forward.sqrMagnitude;
            forward.y = JumpHeight * Mathf.Abs(Mathf.Sin(kyori*kakusokudo));

            var nowPos = transform.position;
            transform.position = new Vector3(nowPos.x + forward.x, forward.y, nowPos.z + forward.z);
        }
        else {
            forward.y = 0.0f;
            kyori = 0;
        }
        if(b!=0)transform.rotation = Quaternion.Euler( transform.eulerAngles+new Vector3(0,b*Time.deltaTime*RotateSpeed,0));

        if (Input.GetKey(KeyCode.Q)) {
            Speed = -3;
        }
    }
}
