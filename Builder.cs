namespace Hello_World
{
    public class Builder: IBuilder
    {
        private IHandler _handler = new Handler();

         public void BuildForFile(string path)
        {
            this._handler.SetStrategy(new ClientForFile()); 
            _handler.HandleFolder(path);
            
        }
        
        public void BuildForConsole(string path)
        {
            this._handler.SetStrategy(new Client()); 
            _handler.HandleFolder(path);

        }

        public void BuildForConsoleandFile(string path)
        {

            this.BuildForConsole(path);
            this.BuildForFile(path);
           


        }
    }
}