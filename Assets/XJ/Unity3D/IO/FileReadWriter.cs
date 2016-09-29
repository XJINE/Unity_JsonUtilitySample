using UnityEngine;
using System.Text;

namespace XJ.Unity3D.IO
{
    /// <summary>
    /// Unity でファイルを読み書きするための機能を提供します。
    /// </summary>
    public static class FileReadWriter
    {
        #region Json

        /// <summary>
        /// 指定したオブジェクトを Json ファイルに出力します。
        /// ファイルは "T.json" として StreamingAssets に出力されます。
        /// </summary>
        /// <typeparam name="T">
        /// Json に出力するオブジェクトのタイプ。
        /// Sample タイプのとき、~StreamingAssets/Sample.json ファイルを出力します。
        /// </typeparam>
        /// <param name="obj">
        /// Json に出力するオブジェクト。
        /// </param>
        /// <returns>
        /// 出力に成功するとき true, 失敗するとき false.
        /// </returns>
        public static bool WriteJsonToStreamingAssets<T>(T obj)
        {
            return WriteFileToStreamingAssets(obj.GetType().Name + ".json", JsonUtility.ToJson(obj));
        }

        /// <summary>
        /// StramingAssets から "T.json" ファイルを読み込み、
        /// タイプ T の新しいインスタンスとして取得します。
        /// </summary>
        /// <typeparam name="T">
        /// Json を読み込み、新しいインスタンスを生成するタイプ。
        /// Sample タイプのとき、~StreamingAssets/Sample.json から読み込みます。
        /// </typeparam>
        /// <returns>
        /// Json から読み込んだ値が設定されたタイプ T のインスタンス。
        /// </returns>
        public static T ReadJsonFromStreamingAssets<T>()
        {
            return JsonUtility.FromJson<T>(ReadFileFromStreamingAssets(typeof(T).Name + ".json"));
        }

        /// <summary>
        /// StramingAssets から "T.json" ファイルを読み込み、
        /// 指定したインスタンスに読み込んだ結果を上書きします。
        /// </summary>
        /// <typeparam name="T">
        /// Json を読み込み、その値を上書きするインスタンスのタイプ。
        /// Sample タイプのとき、~StreamingAssets/Sample.json から読み込みます。
        /// </typeparam>
        /// <param name="obj">
        /// Json を読み込み、その値を上書きするインスタンス。
        /// </param>
        public static void ReadJsonFromStreamingAssets<T>(T obj)
        {
            JsonUtility.FromJsonOverwrite(ReadFileFromStreamingAssets(typeof(T).Name + ".json"), obj);
        }

        #endregion Json

        #region StreamingAssets

        /// <summary>
        /// 指定した内容を UTF-8 形式でファイルに書き込みます。ファイルの内容は上書きされます。
        /// PC(Windows/Mac), Android, iOS で出力先が変更されますが、現在のところ Windows しか保証されません。
        /// </summary>
        /// <param name="relativeFilePath">
        /// ~StramingAssets 以降のファイルパス。
        /// Sample.json とするとき、~StreamingAssets/Sample.json ファイルになります。
        /// </param>
        /// <param name="content">
        /// ファイルに書き込む内容。
        /// </param>
        /// <returns>
        /// 書き込みに成功するとき true, 失敗するとき false.
        /// </returns>
        public static bool WriteFileToStreamingAssets(string relativeFilePath, string content)
        {
            relativeFilePath = OptimizeRelativeFilePath(relativeFilePath);

            return XJ.NET.IO.FileReadWriter.WriteFile
                   (Application.dataPath + GetStreamingAssetsPathConsiderPlatform() + relativeFilePath,
                    content,
                    Encoding.UTF8);
        }

        /// <summary>
        /// ファイルの内容を UTF-8 で読み取り、文字列として取得します。
        /// ファイルパスは StramingAssets ディレクトリから始まる文字列で指定します。
        /// PC(Windows/Mac), Android, iOS で参照先が変更されますが、現在のところ Windows しか保証されません。
        /// </summary>
        /// <param name="relativeFilePath">
        /// ~StramingAssets 以降のファイルパス。
        /// Sample.json とするとき、~StramingAssets/Sample.json ファイルになります。
        /// </param>
        /// <returns>
        /// 読み取った文字列。例外が起きるとき、null.
        /// </returns>
        public static string ReadFileFromStreamingAssets(string relativeFilePath)
        {
            relativeFilePath = OptimizeRelativeFilePath(relativeFilePath);

            return XJ.NET.IO.FileReadWriter.ReadFile
                (Application.dataPath + GetStreamingAssetsPathConsiderPlatform() + relativeFilePath,
                 Encoding.UTF8);
        }

        /// <summary>
        /// PC(Windows/Mac), Android, iOS を考慮して StreamingAssets のファイルパスを取得します。 
        /// 現在のところ Windows 以外動作が保証されません。
        /// </summary>
        /// <returns>
        /// それぞれのプラットフォームに対応する StreamingAssets のファイルパス。
        /// </returns>
        public static string GetStreamingAssetsPathConsiderPlatform()
        {
            // Windows, Mac

            string streamingAssetsPath = "/StreamingAssets";

            // Android

            if (Application.platform == RuntimePlatform.Android)
            {
                streamingAssetsPath = "jar:file://" + Application.dataPath + "!/assets";
            }

            // iOS

            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                streamingAssetsPath = "/Raw";
            }

            return streamingAssetsPath;
        }

        #endregion StreamingAssets

        #region Assets

        /// <summary>
        /// 指定した内容を UTF-8 形式でファイルに書き込みます。ファイルの内容は上書きされます。
        /// </summary>
        /// <param name="relativeFilePath">
        /// ~Assets 以降のファイルパス。Sample.json とするとき、~Assets/Sample.json ファイルになります。
        /// </param>
        /// <param name="content">
        /// ファイルに書き込む内容。
        /// </param>
        /// <returns>
        /// 書き込みに成功するとき true, 失敗するとき false.
        /// </returns>
        public static bool WriteFileToAssets(string relativeFilePath, string content)
        {
            relativeFilePath = OptimizeRelativeFilePath(relativeFilePath);

            return XJ.NET.IO.FileReadWriter.WriteFile(Application.dataPath + relativeFilePath, content, Encoding.UTF8);
        }

        /// <summary>
        /// ファイルの内容を UTF-8 で読み取り、文字列として取得します。
        /// </summary>
        /// <param name="relativeFilePath">
        /// ~Assets 以降のファイルパス。Sample.json とするとき、~Assets/Sample.json ファイルになります。
        /// </param>
        /// <returns>
        /// 読み取った文字列。例外が起きるとき、null.
        /// </returns>
        public static string ReadFileFromAssets(string relativeFilePath)
        {
            relativeFilePath = OptimizeRelativeFilePath(relativeFilePath);

            return XJ.NET.IO.FileReadWriter.ReadFile(Application.dataPath + relativeFilePath, Encoding.UTF8);
        }

        #endregion Assets

        /// <summary>
        /// ファイルパスが相対パスかどうかを検証し、相対パスでないときは相対パスにして返します。
        /// </summary>
        /// <param name="relativeFilePath">
        /// 検証するファイルパス。
        /// </param>
        /// <returns>
        /// 相対パス。
        /// </returns>
        public static string OptimizeRelativeFilePath(string relativeFilePath)
        {
            if (relativeFilePath[0] == '/')
            {
                return relativeFilePath;
            }
            else
            {
                return "/" + relativeFilePath;
            }
        }
    }
}