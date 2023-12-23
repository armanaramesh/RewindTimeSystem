using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TimeControl{

    public enum TimeMode
    {
        none,
        foreward,
        pause,
        backward
    }


    public class TimeController : MonoBehaviour
    {

        public static float gravity = -9.8f;

        [SerializeField] private TimeMode time_Mode = TimeMode.none;

        public struct RecordedData
        {
            public Vector2 pos;
            public Vector2 vel;
            public bool renderer;
        }

        RecordedData[,] recordedData = null;

        [Tooltip("maximume minutes for foreward mode record")]
        [Range(1f, 100f)]
        [SerializeField] private int recordMaxPerMin = 1;


        [Tooltip("minutes of foreward mode record")]
        [SerializeField] private Vector2 recordCountPerMinSecond;



        private int recordMax; // = 100000;  // 100,000 / 60 = 1666 s / 60 = 27.7 min 

        private int recordCount;
        private int recordIndex;


        TimeControlled[] timeObjects;


        // Start is called before the first frame update
        void Start()
        {
            recordMax = recordMaxPerMin * 60 * 60;


            timeObjects = GameObject.FindObjectsOfType<TimeControlled>();
            foreach (TimeControlled timeObject in timeObjects)
            {
                timeObject.TimeStart();
            }
            recordedData = new RecordedData[timeObjects.Length, recordMax];
        }

        // Update is called once per frame
        void Update()
        {
            if (recordCount < recordMax)
            {
                bool pause = Input.GetKey(KeyCode.Space);
                bool stepBack = Input.GetKey(KeyCode.B);

                if (stepBack)
                {
                    time_Mode = TimeMode.backward;

                    if (recordIndex > 0)
                    {
                        recordIndex--;

                        convertRecordToMinSec(recordIndex);

                    }

                    for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
                    {
                        TimeControlled timeObject = timeObjects[objectIndex];
                        RecordedData data = recordedData[objectIndex, recordIndex];

                        timeObject.transform.position = data.pos;
                        timeObject.velocity = data.vel;
                        timeObject.meshRenderer = data.renderer;
                    }

                    foreach (TimeControlled timeObject in timeObjects)
                    {
                        timeObject.TimeUpdate();
                    }

                }
                else if (pause)
                {
                    time_Mode = TimeMode.pause;
                    if (recordIndex < recordCount - 1)
                    {
                        recordIndex++;
                        for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
                        {
                            TimeControlled timeObject = timeObjects[objectIndex];
                            RecordedData data = recordedData[objectIndex, recordIndex];

                            timeObject.transform.position = data.pos;
                            timeObject.velocity = data.vel;
                            timeObject.meshRenderer = data.renderer;
                        }
                    }

                }
                else if (!pause && !stepBack)   // foreward mode
                {



                    if (time_Mode == TimeMode.backward || time_Mode == TimeMode.pause)
                    {
                        time_Mode = TimeMode.foreward;
                        recordCount = recordIndex;

                    }

                    // record data
                    for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
                    {
                        TimeControlled timeObject = timeObjects[objectIndex];
                        RecordedData data = new RecordedData();
                        data.pos = timeObject.transform.position;
                        data.vel = timeObject.velocity;
                        data.renderer = timeObject.meshRenderer;

                        recordedData[objectIndex, recordCount] = data;


                    }

                    recordCount++;
                    recordIndex = recordCount;
                    convertRecordToMinSec(recordCount);

                    foreach (TimeControlled timeObject in timeObjects)
                    {
                        timeObject.TimeUpdate();
                    }
                }
            }

            else
            {
                time_Mode = TimeMode.none;
                recordCount = 0;
            }


        }

        private void convertRecordToMinSec(int count)
        {
            int seconds = count / 60;
            int minuntes = seconds / 60;
            int remainSeconds = seconds - minuntes * 60;

            recordCountPerMinSecond.x = minuntes;
            recordCountPerMinSecond.y = remainSeconds;
        }



        // need a list for saving event raising time




    }




}



