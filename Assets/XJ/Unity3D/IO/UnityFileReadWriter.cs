using UnityEngine;
using System.Text;
using XJ.NET.IO;

namespace XJ.Unity3D.IO
{
    public static class UnityFileReadWriter
    {
        /// <summary>
        /// 指定した内容を UTF-8 形式でファイルに書き込みます。
        /// ファイルの内容は上書きされます。
        /// </summary>
        /// <param name="relativeFilePath">
        /// ファイル名。
        /// </param>
        /// <param name="content">
        /// ファイルに書き込む内容。
        /// </param>
        /// <returns>
        /// 書き込みに成功するとき true, 失敗するとき false.
        /// </returns>
        public static bool WriteFile(string relativeFilePath, string content)
        {
            relativeFilePath = optimizeRelativeFilePath(relativeFilePath);
            return FileReadWriter.WriteFile(Application.dataPath + relativeFilePath, content, Encoding.UTF8);
        }
        
        /// <summary>
        /// ファイルの内容を UTF-8 で読み取り、文字列として取得します。
        /// </summary>
        /// <param name="relativeFilePath">
        /// ファイル名。
        /// </param>
        /// <returns>
        /// 読み取った文字列。例外が起きるとき、null.
        /// </returns>
        public static string ReadFile(string relativeFilePath)
        {
            relativeFilePath = optimizeRelativeFilePath(relativeFilePath);
            return FileReadWriter.ReadFile(Application.dataPath + relativeFilePath, Encoding.UTF8);
        }

        /// <summary>
        /// ファイルパスが相対パスかどうかを検証し、相対パスでないときは相対パスにして返します。
        /// </summary>
        /// <param name="relativeFilePath">
        /// 検証するファイルパス。
        /// </param>
        /// <returns>
        /// 相対パス。
        /// </returns>
        private static string optimizeRelativeFilePath(string relativeFilePath)
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