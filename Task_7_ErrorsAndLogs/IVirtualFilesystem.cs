using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_ErrorsAndLogs
{
    internal interface IVirtualFilesystem
    {
        int CreateFolder(string locationPath, List<Folder> folderList);
        //int CreateFile(string locationPath, List<File> fileList);
    }
}
