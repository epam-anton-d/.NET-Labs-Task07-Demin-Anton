using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_ErrorsAndLogs
{
    internal class Files : IVirtualFilesystem
    {
        private string name;
        private string extension;
        private string locationFolder;
    
        public string Name { set; get; }
        public string LocationFolder { set; get; }
        public string Extension { set; get; }
    
        public Files(string name, string locationFolder)
        {
            this.Name = name;
            this.LocationFolder = locationFolder;
        }
    
        // 
        //private bool IsExist(string name, string motherFolder, List<Folder> folderList)
        //{
        //    foreach (Folder item in folderList)
        //    {
        //        if (item.Name == name && item.LocationFolder == motherFolder)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private bool IsExist(string locationPath, List<Folder> folderList)
        {
            foreach (Folder item in folderList)
            {
                if (locationPath == item.LocationFolder + "\\" + item.Name || locationPath == "c:")
                {
                    return true;
                }
            }
            return false;
        }

        // works.
        private bool IsExistTwice(string nameFile, string nameFolder, List<Files> fileList, List<Folder> folderList)
        {
            foreach (Files item in fileList)
            {
                if (nameFolder + "\\" + nameFile == item.locationFolder + "\\" + item.Name)
                {
                    return true;
                }
            }
            return false;
        }
        //{
        //    foreach (Files item in fileList)
        //    {
        //        if (item.Name == nameFile && item.locationFolder == nameFolder)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    
        public int Create(string locationPath, List<Files> fileList, List<Folder> folderList)
        {
            char[] slash = new char[] { '\\' };
            string[] folderDir = locationPath.Split(slash);
            string path = "";
            for(int i = 0; i < folderDir.Length - 1; i++)
            {
                if(folderDir[i] != "")
                    path += folderDir[i];
                if (i != folderDir.Length - 2)
                    path += "\\";
            }
            string endPath = folderDir[folderDir.Length - 1];
            
            if (!IsExist(path, folderList))
            {
                return 1; // Несуществующий путь.
            }
            
            if (IsExistTwice(endPath, path, fileList, folderList))
            {
                return 2; // Файл в заданной директории уже существует.
            }
            try
            {
                fileList.Add(new Files(endPath, path));//folderDir[folderDir.Length - 2]));
                return 0;
            }
            catch
            {
                return 3; // Неизвестная ошибка.
            }
        }
    }
}
