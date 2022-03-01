
namespace Hello_World
{
    public interface IAnaplanClient
    {
        public void SetImportFile(string path, byte[] array, int count);
 
         public void StartAction(string taskId);
 
 
     }
} 
