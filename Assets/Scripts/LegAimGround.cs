using UnityEngine;

[ExecuteAlways]
public class LegAimGround : MonoBehaviour
{
    private RaycastHit _raycastHit;
    private GameObject _originParent;

    private int GroundMask => 1 << 6;

    private void Awake() => 
        _originParent = transform.parent.gameObject;

    private void FixedUpdate()
    {
        if (Physics.Raycast(_originParent.transform.position, -transform.up, out _raycastHit, Mathf.Infinity, GroundMask))
            transform.position = _raycastHit.point;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(_originParent.transform.position, -transform.up, Color.green);
        Gizmos.color = new Color(255, 0, 0, 1);
        Gizmos.DrawCube(transform.position, new Vector3(0.3f,0.3f, 0.3f));
    }
}
