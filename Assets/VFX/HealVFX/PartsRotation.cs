using UnityEngine;

public class PartsRotation : MonoBehaviour
{
    [SerializeField]
    public Transform RotationPart;
    [SerializeField]
    public float xAngle, yAngle, zAngle;
    // Update is called once per frame
    void Update()
    {
        RotationPart.transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.Self);
    }
}
