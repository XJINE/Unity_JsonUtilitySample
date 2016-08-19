using System.IO;
using System.Text;

namespace XJ.NET.IO
{
    /// <summary>
    /// ファイルを読み書きするための機能を提供します。
    /// </summary>
    public static class FileReadWriter
    {
        /// <summary>
        /// 指定した内容を UTF-8 形式でファイルに書き込みます。
        /// ファイルの内容は上書きされます。
        /// </summary>
        /// <param name="filePath">
        /// ファイルパス。
        /// </param>
        /// <param name="content">
        /// ファイルに書き込む内容。
        /// </param>
        /// <returns>
        /// 書き込みに成功するとき true.
        /// </returns>
        public static bool WriteFile(string filePath, string content)
        {
            return WriteFile(filePath, content, Encoding.UTF8);
        }

        /// <summary>
        /// 指定した内容をファイルに書き込みます。
        /// ファイルの内容は上書きされます。
        /// </summary>
        /// <param name="filePath">
        /// ファイルパス。
        /// </param>
        /// <param name="content">
        /// ファイルに書き込む内容。
        /// </param>
        /// <param name="encoding">
        /// 文字エンコード。
        /// </param>
        /// <returns>
        /// 書き込みに成功するとき true.
        /// </returns>
        public static bool WriteFile(string filePath, string content, Encoding encoding)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            StreamWriter streamWriter = new StreamWriter(filePath, false, encoding);
            streamWriter.WriteLine(content);
            streamWriter.Close();
            streamWriter.Dispose();
            streamWriter = null;

            return true;
        }

        /// <summary>
        /// ファイルの内容を UTF-8 で読み取り、文字列として取得します。
        /// </summary>
        /// <param name="filePath">
        /// ファイルパス。
        /// </param>
        /// <returns>
        /// 読み取った文字列。例外が起きるとき、null.
        /// </returns>
        public static string ReadFile(string filePath)
        {
            return ReadFile(filePath, Encoding.UTF8);
        }

        /// <summary>
        /// ファイルの内容を読み取り文字列として取得します。
        /// </summary>
        /// <param name="filePath">
        /// ファイルパス。
        /// </param>
        /// <param name="encoding">
        /// エンコーディング。
        /// </param>
        /// <returns>
        /// 読み取った文字列。
        /// </returns>
        public static string ReadFile(string filePath, Encoding encoding)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            StreamReader streamReader = new StreamReader(fileInfo.OpenRead(), encoding);

            string result = streamReader.ReadToEnd();

            streamReader.Dispose();
            streamReader = null;

            return result;
        }
    }
}