using UnityEngine;
using System.Collections;

namespace XJ.Unity3D.IO
{
    public class FileReadWriterSample_Json : MonoBehaviour
    {
        public SampleClass sampleClass;

        public KeyCode SetRandomValueKey = KeyCode.S;
        public KeyCode WriteJsonKey = KeyCode.W;
        public KeyCode ReadJsonKey = KeyCode.R;
        public KeyCode DebugLogJsonKey = KeyCode.D;

        void Start()
        {
            this.sampleClass = new SampleClass();
            this.sampleClass.SetRandomValue();
        }

        void Update()
        {
            if (Input.GetKeyDown(this.SetRandomValueKey))
            {
                this.sampleClass.SetRandomValue();
            }

            if (Input.GetKeyDown(this.WriteJsonKey))
            {
                if (FileReadWriter.WriteJsonToStreamingAssets<SampleClass>(this.sampleClass))
                {
                    Debug.Log("Success : Write Json.");
                }
                else
                {
                    Debug.Log("Failure : Write Json.");
                }
            }

            if (Input.GetKeyDown(this.ReadJsonKey))
            {
                this.sampleClass = FileReadWriter.ReadJsonFromStreamingAssets<SampleClass>();
            }

            if (Input.GetKeyDown(this.DebugLogJsonKey))
            {
                Debug.Log(JsonUtility.ToJson(this.sampleClass));
            }
        }
    }
}