public class MidiPlayer
{
    //Win32 MCIの参照
    [System.Runtime.InteropServices.DllImport("winmm.dll")]
    private static extern int mciSendString(string command,
        System.Text.StringBuilder? buffer, int bufferSize, IntPtr hwndCallback);

    private string aliasName = "MediaFile";

    //メディアのロードメソッド
    private void MediaLoad()
    {
        //再生するファイル名
        string fileName = "D:\\Music\\MIDI\\disgtel.mid";
        string cmd;
        //ファイルを開く
        Console.WriteLine("Loading...");
        cmd = "open \"" + fileName + "\" alias " + aliasName;
        mciSendString(cmd, null, 0, IntPtr.Zero);
        //ファイルの再生
        cmd = "play " + aliasName;
        mciSendString(cmd, null, 0, IntPtr.Zero);
        Console.WriteLine("Loaded");
    }

    public void MidiStop()
    {
        string cmd;
        //再生しているWAVEを停止する
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
            Console.WriteLine("Press the spacebar to play");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Spacebar)
            {
                player.MediaLoad();
            }

        }

    }

}