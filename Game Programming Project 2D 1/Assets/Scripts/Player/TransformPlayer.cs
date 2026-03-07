using UnityEngine;

public class TransformPlayer : MonoBehaviour
{
    public void recieveBollPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
