using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_ErrorsAndLogs
{
    internal interface IVirtualFilesystem
    {
        int Create(string locationPath, List<Files> fileList, List<Folder> folderList);
    }
}
