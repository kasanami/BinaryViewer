using System;
using System.Text;
using System.IO;

namespace BinaryViewer
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            // デバッグ用に読み込むファイル
            args = new string[] { "../../Program.cs" };
#endif
            if (args.Length < 1)
            {
                Console.WriteLine("BinaryViewer");
                Console.WriteLine("第1引数に開くファイルのパスを指定する。");
                return;
            }
            var path = args[0];
            try
            {
                var fileStream = File.OpenRead(path);
                Console.WriteLine(path + "を正常に開けた。");

                while (true)
                {
                    var bytes = new byte[16];// 0で初期化も兼ねている
                    var readBytes = fileStream.Read(bytes, 0, bytes.Length);
                    for (int i = 0; i < readBytes; i++)
                    {
                        Console.Write(bytes[i].ToString("X2") + " ");
                    }
                    var s = Encoding.UTF8.GetString(bytes).Replace('\n', ' ').Replace('\r', ' ');
                    Console.WriteLine(s);
                    if (readBytes < bytes.Length)
                    {
                        break;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
