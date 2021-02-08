using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour, ISelectController
{
    [SerializeField] int _outlineLayer;
    [SerializeField] int _defaultLayer;
    [SerializeField] GameObject _target;
    [SerializeField]
    [RequireInterface(typeof(IDoAction))]
    private Object _action;
    private IDoAction Action => _action as IDoAction;

    public void SelectOn()
    {
        if (_target != null)
            _target.layer = _outlineLayer;
    }

    public void SelectOff()
    {
        if (_target != null)
            _target.layer = _defaultLayer;
    }

    public void DoAction()
    {
        if (Action == null)
            Debug.LogError("There is not _doAction object");
        else
            Action.DoAction();
    }
}
