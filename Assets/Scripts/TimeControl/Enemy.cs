using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControl;


public class Enemy : TimeControlled
{

    

    public override void TimeStart()
    {
        meshRenderer = true;
        StartCoroutine(deactivator());
    }

    IEnumerator deactivator()
    {
        yield return new WaitForSeconds(5f);
        
        meshRenderer = false;

    }

    public override void TimeUpdate()
    {
        //base.TimeUpdate();

        Vector2 pos = transform.position;
        pos.x += Time.deltaTime;
        transform.position = pos;

        this.gameObject.GetComponent<MeshRenderer>().enabled = meshRenderer;


    }
}
