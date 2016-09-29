using UnityEngine;

public class JsonUtilitySample : MonoBehaviour
{
    #region Field

    public string fileName = "JSON/sample.json";

    public KeyCode Key_SetRandomValue = KeyCode.S;
    public KeyCode Key_ReadValue = KeyCode.R;
    public KeyCode Key_WriteValue = KeyCode.W;
    public KeyCode Key_DebugLog = KeyCode.D;

    [UnityEngine.SerializeField]
    public SampleClass sampleClass = new SampleClass();

    #endregion Field

    void Update()
    {
        // ランダムな値を SampleClass に設定します。

        if (Input.GetKeyDown(this.Key_SetRandomValue))
        {
            this.sampleClass.SetRandomValue();
        }

        // Json から値を読み込み、SampleClass に設定します。

        if (Input.GetKeyDown(this.Key_ReadValue))
        {
            this.sampleClass = JsonUtility.FromJson<SampleClass>
                (XJ.Unity3D.IO.FileReadWriter.ReadFileFromAssets(this.fileName));
        }

        // SampleClass の値を Json に書き込みます。

        if (Input.GetKeyDown(this.Key_WriteValue))
        {
            if (XJ.Unity3D.IO.FileReadWriter.WriteFileToAssets
                (this.fileName, JsonUtility.ToJson(this.sampleClass)) == false)
            {
                Debug.Log("File Write Failed.");
            }
        }

        // SampleClass の値を Json にしてログに出力します。

        if (Input.GetKeyDown(this.Key_DebugLog))
        {
            Debug.Log(JsonUtility.ToJson(this.sampleClass));
        }
    }
}