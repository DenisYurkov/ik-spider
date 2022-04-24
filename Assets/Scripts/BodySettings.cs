using UnityEngine;

[CreateAssetMenu(fileName = "BodySettings", menuName = "IK/BodySettings", order = 0)]
public class BodySettings : ScriptableObject
{
    public float LegMoveSpeed;
    public float CheckDistance;
}