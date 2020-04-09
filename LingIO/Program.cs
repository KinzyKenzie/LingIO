using System;

namespace LingIO
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main() {
            using( var game = new LingIO() )
                game.Run();
        }
    }
#endif
}
