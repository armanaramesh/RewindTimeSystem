using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControl;
using ScriptableObjectArchitecture;

public class Enemy : TimeControlled
{

    public GameEvent onEnemiesDisapeard;

    public override void TimeStart()
    {
        StartCoroutine(deactivator());
    }

    IEnumerator deactivator()
    {
        yield return new WaitForSeconds(5f);
        onEnemiesDisapeard.Raise();
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    public override void TimeUpdate()
    {
        //base.TimeUpdate();

        Vector2 pos = transform.position;
        pos.x += Time.deltaTime;
        transform.position = pos;


    }
}
