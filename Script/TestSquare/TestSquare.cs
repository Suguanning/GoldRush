using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSquare : MonoBehaviour
{
    public int object_id;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnObjectMoveTriggerEnter += OnMove;
        GameEvents.current.OnObjectBackTriggerEnter += OnMoveBack;
    }

    private void OnMove(int object_id)
    {
        if (object_id == this.object_id) {
            LeanTween.moveLocalY(gameObject, 1.61f, 3f).setEaseOutExpo();
        }
    }

    private void OnMoveBack(int object_id)
    {
        if (object_id == this.object_id)
        {
            LeanTween.moveLocalY(gameObject, -1.05f, 3f).setEaseOutExpo();
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.OnObjectMoveTriggerEnter -= OnMove;
        GameEvents.current.OnObjectBackTriggerEnter -= OnMoveBack;
    }
}
