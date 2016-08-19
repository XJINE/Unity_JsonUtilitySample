using UnityEngine;

public class JsonUtilitySample : MonoBehaviour
{
    #region Field

    public string fileName = "JSON/sample.json";

    public KeyCode Key_SetRandomValue = KeyCode.A;
    public KeyCode Key_ReadValue = KeyCode.R;
    public KeyCode Key_WriteValue = KeyCode.W;
    public KeyCode Key_DebugLog = KeyCode.D;

    [UnityEngine.SerializeField]
    public SampleClass sampleClass = new SampleClass();

    #endregion Field

    void Update()
    {
        if (Input.GetKeyDown(this.Key_SetRandomValue))
        {
            this.sampleClass.SetRandomValue();
        }
        if (Input.GetKeyDown(this.Key_ReadValue))
        {
            this.sampleClass = JsonUtility.FromJson<SampleClass>
                (XJ.Unity3D.IO.UnityFileReadWriter.ReadFile(this.fileName));
        }
        if (Input.GetKeyDown(this.Key_WriteValue))
        {
            if (XJ.Unity3D.IO.UnityFileReadWriter.WriteFile
                (this.fileName, JsonUtility.ToJson(this.sampleClass)) == false)
            {
                Debug.Log("File Write Failed.");
            }
        }
        if (Input.GetKeyDown(this.Key_DebugLog))
        {
            Debug.Log(JsonUtility.ToJson(this.sampleClass));
        }
    }
}