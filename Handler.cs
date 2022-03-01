using System;
using System.IO;


namespace Hello_World
{
    public class Handler: IHandler 
    { 
        private  IAnaplanClient _client;
        

        private int fileChunkSize;

        private bool useFilePartitioning;
        public int FileChunkSize {get; set;}
        public bool UseFilePartitioning {get; set;}
        
        public Handler ()
        {
            _client=new Client();
            this.fileChunkSize = 50;
            this.useFilePartitioning = true;

        } 

        public Handler (IAnaplanClient strategy)
        {
            _client=strategy;
            

            this.fileChunkSize = 50;
            this.useFilePartitioning = true;

        } 

        public void SetStrategy(IAnaplanClient strategy)
        {
            this._client = strategy;
        }

        public Handler (int size)
        {
            _client=new Client();

            this.fileChunkSize = size;
            this.useFilePartitioning = true;

        }

        

        public void HandleFolder(string folderPath)
        { 
     
 
            foreach (var path in Directory.GetFiles(folderPath, "*.*"))
            {
                FileStream file = File.OpenRead(path);
                int ChunkCount = this.GetFileChunkCount(file);
                 _client.StartAction (path);

                  for (int chunk = 0;chunk<ChunkCount; chunk++)
                    {

                        byte[] array = new byte[this.fileChunkSize];
                        file.Read(array, 0, array.Length);
                        _client.SetImportFile(folderPath, array, chunk);
                                     
                    }

            }
        }

        private int GetFileChunkCount(FileStream file)
        {
            int chunkCount = 0;
 
            byte[] array = new byte[file.Length];
            int partsize = this.fileChunkSize;
            int chunkDiff = array.Length;

            if (chunkDiff>partsize)
            {
                chunkCount = chunkDiff/partsize;
                chunkCount = (chunkDiff%partsize)>0 ? chunkCount++:chunkCount;
            }

            else
            {
 
                this.useFilePartitioning = false;
                chunkCount = 1;
            }
 
            return chunkCount;
 
 
        }

        private string[] GetActions(string folderPath)
        {
 
            string[] second = Directory.GetFiles(folderPath); // путь к папке
            int index = second[0].LastIndexOf('/');
 
            for (int i = 0; i < second.Length; i++)
            {
 
                second[i] = second[i].Substring(index+1);

            } 
 
            return second; 
        }

        

 

    }

}