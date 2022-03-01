namespace Hello_World
{
    public interface IHandler
    {

        public void SetStrategy(IAnaplanClient strategy);
        public void HandleFolder(string folderPath);//считывает файл
 
 
    }
}
