using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 previousPosition;
    public Text TextFrame;

    public static Speedometer instance;
    private float speed;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousPosition = rb.position;
    }

    void FixedUpdate()
    {
        speed = rb.velocity.magnitude * 4;
        // Debug.Log("Speed: " + speed);


        TextFrame.text = string.Format("speed:{0:000.0}", speed);

        previousPosition = rb.position;
    }
    public float GetSpeed()
    {
        return speed;
    }
}
