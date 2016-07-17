using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_ErrorsAndLogs
{
    internal class Folder : IVirtualFilesystem//, IEquatable<Folder>
    {
        private string name;
        private string locationFolder;

        public string Name { set; get; }
        public string LocationFolder { set; get; }

        public Folder(string name, string locationFolder)
        {
            this.Name = name;
            this.LocationFolder = locationFolder;
        }

        public bool IsExist(string name, List<Folder> folderList)
        {
            foreach (Folder item in folderList)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsExistTwice(string name, string motherFolder, List<Folder> folderList)
        {
            foreach (Folder item in folderList)
            {
                if (item.Name == name && item.locationFolder == motherFolder)
                {
                    return true;
                }
            }
            return false;
        }
        
        public int CreateFolder(string locationPath, List<Folder> folderList)
        {
            char[] slash = new char[] { '\\' };
            string[] folderDir = locationPath.Split(slash);
            for (int i = 1; i < folderDir.Length - 2; i++)
            {
                if (!IsExist(folderDir[i], folderList))
                {
                    return 1; // Несуществующий путь.
                }
            }
            if(IsExistTwice(folderDir[folderDir.Length - 1], folderDir[folderDir.Length - 2], folderList))
            {
                return 2; // Файл в заданной директории уже существует.
            }
            //List<Folder> folderList = new List<Folder>();
            if (!IsExist(folderDir[folderDir.Length - 1], folderList) && IsExist(folderDir[folderDir.Length - 2], folderList))
            {
                folderList.Add(new Folder(folderDir[folderDir.Length - 1], folderDir[folderDir.Length - 2]));
                return 0;
            }
            return 3; // Неизвестная ошибка.
        }
    }
}
