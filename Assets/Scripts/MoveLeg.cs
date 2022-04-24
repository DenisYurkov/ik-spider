using System.Collections;
using DG.Tweening;
using UnityEngine;

public class MoveLeg : MonoBehaviour
{
    [SerializeField] private BodySettings _bodySettings;
    [SerializeField] private GameObject _moveCude;
    [SerializeField] private MoveLeg _oppositeLeg;

    private Vector3 _targetPos;
    private Vector3 _defaultPosition;
    private bool _isMove;

    private bool CheckDistance => 
        Vector3.Distance(transform.position, _moveCude.transform.position) >= _bodySettings.CheckDistance;

    private void Awake()    
    {
        _defaultPosition = transform.position;
        _targetPos = _defaultPosition;
    }

    private void Update()
    {
        if (CheckDistance && !_oppositeLeg._isMove)
            StartCoroutine(Step());
        else
        {
            _targetPos.y = _defaultPosition.y;
            transform.position = _targetPos;
        }
    }

    private IEnumerator Step()
    {
        _isMove = true;
        var tween = transform.DOMove(_moveCude.transform.position + new Vector3(0, 0.3f, 0),
            _bodySettings.LegMoveSpeed).OnComplete(() =>
        {
            _targetPos = transform.position;
            _isMove = false;
        });
        yield return tween.WaitForCompletion();
    }

    
    private void OnDrawGizmos() => 
        Debug.DrawLine(transform.position, _moveCude.transform.position, Color.red);
}