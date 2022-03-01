namespace Hello_World
{
    public interface IBuilder
    {
        public void BuildForFile (string path);
        public void BuildForConsole(string path);
        public void BuildForConsoleandFile(string path); 
    }
}