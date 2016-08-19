using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SampleClass
{
    // uint, (u)long, (s)byte, double はここでは未検証。
    // おそらく問題なく実現できる。

    public int intValue;
    private int privateIntValue;
    [UnityEngine.SerializeField]
    private int serializablePrivateIntValue;

    public int[] intArray;
    public List<int> intList;

    public float floatValue;
    public bool boolValue;
    public char charValue;
    public string stringValue;

    public Vector2 vector2Value;
    public Vector3 vector3Value;
    public Vector4 vector4Value;
    public Quaternion quaternionValue;
    public Matrix4x4 matrixValue;
    public Transform transformValue;

    public SampleEnum sampleEnum;
    public enum SampleEnum
    {
        enumItem1,
        enumItem2,
        enumItem3
    }

    public SerializableStruct sampleStruct;
    [System.Serializable]
    public struct SerializableStruct
    {
        public int intValue;
    }

    public SerializableClass sampleClass;
    [System.Serializable]
    public class SerializableClass
    {
        public int intValue;
    }

    public List<SerializableStruct> structList;

    public List<SerializableClass> classList;

    // JsonUtility は以下のフィールド(プロパティ)には対応しません。
    // (標準では対応しない)

    [UnityEngine.SerializeField]
    public static int staticIntValue;

    [UnityEngine.SerializeField]
    public int IntProperty { get; set; }

    [UnityEngine.SerializeField]
    public int[][] jaggedIntArray;

    [UnityEngine.SerializeField]
    public Dictionary<int, string> dictionaryValue;

    public void SetRandomValue()
    {
        this.intValue = Random.Range(1, 10);
        this.privateIntValue = Random.Range(1, 10);
        this.serializablePrivateIntValue = Random.Range(1, 10);

        this.intArray = new int[Random.Range(1, 5)];
        for (int i = 0; i < this.intArray.Length; i++)
        {
            this.intArray[i] = Random.Range(1, 10);
        }

        this.intList = new List<int>();
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            this.intList.Add(Random.Range(1, 10));
        }

        this.floatValue = Random.Range(1, 10.0f);
        this.boolValue = Random.Range(0, 2) == 1 ? true : false;
        this.charValue =  Random.Range(1, 10).ToString()[0];
        this.stringValue = Random.Range(1, 10).ToString();

        this.vector2Value = new Vector2(Random.Range(1, 10.0f),
                                        Random.Range(1, 10.0f));
        this.vector3Value = new Vector3(Random.Range(1, 10.0f),
                                        Random.Range(1, 10.0f),
                                        Random.Range(1, 10.0f));
        this.vector4Value = new Vector4(Random.Range(1, 10.0f),
                                        Random.Range(1, 10.0f),
                                        Random.Range(1, 10.0f),
                                        Random.Range(1, 10.0f));
        this.quaternionValue = new Quaternion()
        {
            x = Random.Range(1, 10.0f),
            y = Random.Range(1, 10.0f),
            z = Random.Range(1, 10.0f),
            w = Random.Range(1, 10.0f)
        };
        this.matrixValue = new Matrix4x4()
        {
            m00 = Random.Range(1, 10.0f),
            m01 = Random.Range(1, 10.0f),
            m02 = Random.Range(1, 10.0f),
            m03 = Random.Range(1, 10.0f),
            m10 = Random.Range(1, 10.0f),
            m11 = Random.Range(1, 10.0f),
            m12 = Random.Range(1, 10.0f),
            m13 = Random.Range(1, 10.0f),
            m20 = Random.Range(1, 10.0f),
            m21 = Random.Range(1, 10.0f),
            m22 = Random.Range(1, 10.0f),
            m23 = Random.Range(1, 10.0f),
            m30 = Random.Range(1, 10.0f),
            m31 = Random.Range(1, 10.0f),
            m32 = Random.Range(1, 10.0f),
            m33 = Random.Range(1, 10.0f),
        };

        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        if (gameObjects != null && gameObjects.Length != 0)
        {
            this.transformValue = gameObjects[Random.Range(0, gameObjects.Length)].transform;
        }

        this.sampleEnum = (SampleEnum)Random.Range(0,3);

        this.sampleStruct = new SerializableStruct()
        {
            intValue = Random.Range(1, 10)
        };

        this.sampleClass = new SerializableClass()
        {
            intValue = Random.Range(1, 10)
        };

        this.structList = new List<SerializableStruct>()
        {
            new SerializableStruct() { intValue = Random.Range(1, 10) }
        };

        this.classList = new List<SerializableClass>()
        {
            new SerializableClass() { intValue = Random.Range(1, 10) }
        };

        // JsonUtility は以下のフィールド(プロパティ)には対応しません。

        SampleClass.staticIntValue = Random.Range(1, 10);

        this.IntProperty = Random.Range(1, 10);

        this.jaggedIntArray = new int[Random.Range(1, 5)][];
        for (int i = 0; i < this.jaggedIntArray.Length; i++)
        {
            this.jaggedIntArray[i] = new int[i];
            for (int j = 0; j < this.jaggedIntArray[i].Length; j++)
            {
                this.jaggedIntArray[i][j] = Random.Range(1, 10);
            }
        }

        this.dictionaryValue = new Dictionary<int, string>()
        {
            { Random.Range(1, 10), Random.Range(1, 10).ToString() }
        };
    }
}