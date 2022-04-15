public class MidiPlayer
{
    //Win32 MCIの参照
    [System.Runtime.InteropServices.DllImport("winmm.dll")]
    private static extern int mciSendString(string command,
        System.Text.StringBuilder? buffer, int bufferSize, IntPtr hwndCallback);

    private string aliasName = "MediaFile";
    private string cmd = "";

    //メディアのロードメソッド
    private void MediaLoad()
    {
        //再生するファイル名
        string fileName = "D:\\Music\\MIDI\\Roundabout.mid";
        //ファイルを開く
        Console.WriteLine("Loading...");
        cmd = "open \"" + fileName + "\" alias " + aliasName;
        mciSendString(cmd, null, 0, IntPtr.Zero);
    }
    private void MediaPlay()
    {
        //ファイルの再生
        cmd = "play " + aliasName;
        mciSendString(cmd, null, 0, IntPtr.Zero);
        Console.WriteLine("Now Playing");
    }

    public void MediaStop()
    {
        //再生を停止する
        cmd = "stop " + aliasName;
        mciSendString(cmd, null, 0, IntPtr.Zero);
    }

    public void MediaEnd()
    {
        //再生を停止する
        cmd = "stop " + aliasName;
        mciSendString(cmd, null, 0, IntPtr.Zero);
        //閉じる
        cmd = "close " + aliasName;
        mciSendString(cmd, null, 0, IntPtr.Zero);
    }

    //メインループ
    static void Main()
    {
        bool isLoopFlag = true;
        //キー入力変数
        ConsoleKeyInfo key;
        MidiPlayer player = new MidiPlayer();

        while (isLoopFlag)
        {
            Console.WriteLine("[L]oad 読み込み");
            Console.WriteLine("[Space] 再生");
            Console.WriteLine("[S]top 停止");
            Console.WriteLine("[Q]uit 終了");
            Console.WriteLine("[Escape] 閉じる");
            key = Console.ReadKey(true);
            switch(key.Key)
            {
                case ConsoleKey.L:
                    player.MediaLoad();
                    break;
                case ConsoleKey.Spacebar:
                    player.MediaPlay();
                    break;
                case ConsoleKey.Q:
                    player.MediaEnd();
                    break;
                case ConsoleKey.S:
                    player.MediaStop();
                    break;
                case ConsoleKey.Escape:
                    isLoopFlag = false;
                    break;

            }

        }

    }

}