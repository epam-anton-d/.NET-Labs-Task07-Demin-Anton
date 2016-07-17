using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_ErrorsAndLogs
{
    internal class Folder : IVirtualFilesystem
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


        // true
        private bool IsExist(string locationPath, List<Folder> folderList)
        {
            foreach (Folder item in folderList)
            {
                if(locationPath == item.LocationFolder + "\\" + item.Name || locationPath == "c:")
                {
                    return true;
                }
            }
            return false;
        }
        //{
        //    foreach (Folder item in folderList)
        //    {
        //        if (item.Name == name && item.LocationFolder == path)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ////private bool IsExistTwice(string nameFolder, string path, List<Folder> folderList)
        ////{
        ////    foreach (Folder item in folderList)
        ////    {
        ////        if (path + nameFolder == item.locationFolder + item.Name)
        ////        {
        ////            return true;
        ////        }
        ////    }
        ////    return false;
        ////}
        //{
        //    foreach (Folder item in folderList)
        //    {
        //        if (item.Name == nameFolder && item.locationFolder == path)
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
                path += folderDir[i];
                if (i != folderDir.Length - 2)
                    path += "\\";
            }
            string endPath = folderDir[folderDir.Length - 1];
            
            if (!IsExist(path, folderList))
            {
                return 1; // Несуществующий путь.
            }
            
            if(IsExist(path + "\\" + endPath, folderList))
            {
                return 2; // Папка в заданной директории уже существует.
            }
            try
            {
                folderList.Add(new Folder(endPath, path));//folderDir[folderDir.Length - 2]));
                return 0;
            }
            catch
            {
                return 3; // Неизвестная ошибка.
            }
        }
    }
}
