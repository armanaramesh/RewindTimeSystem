using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;


namespace TimeControl
{

    /// <summary>
    /// 
    /// </summary>
    public class TimeControlled : MonoBehaviour
    {

        // parameters or properties for control
        public Vector2 position;
        public Vector2 velocity;
        public bool meshRenderer;

        //for animation clip control
        public float animTime;
        public AnimationClip currentAnim;
        




        public GameEvent _onEnemiesDisapeard;


        public virtual void TimeStart()
        {

        }

        public virtual void TimeUpdate()
        {
            
        }


        public virtual void AnimationUpdate() 
        { 
            
        
        }
    }


}

    
