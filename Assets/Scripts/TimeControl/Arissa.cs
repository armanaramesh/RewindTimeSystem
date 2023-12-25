using System.Collections;
using System.Collections.Generic;
using TimeControl;
using UnityEngine;

public class Arissa : TimeControlled
{
    // first , manipulate pattern for design

    
    public override void TimeStart()
    {
        //base.TimeStart();


    }


    public override void TimeUpdate()
    {
        //base.TimeUpdate();

        // need to check current anim




        // loop anim time
        if (currentAnim != null)
        {
            animTime += Time.deltaTime;
            if (animTime > currentAnim.length)
            {
                animTime -= currentAnim.length;
            }
        }

    }


    public override void AnimationUpdate()
    {
        //base.AnimationUpdate();

        if (currentAnim != null)
        {
            currentAnim.SampleAnimation(gameObject, animTime);
        }


    }


}
