using System;
using System.Collections.Generic;
using System.Text;

namespace Extension.DirectoryInfo
{
    public static class DirectoryInfoExtension
    {
        /// <summary>
        /// 해당 디렉토리 내 모든 서브 디렉토리를 탐색하여 모든 파일의 경로를 반환합니다.
        /// </summary>
        /// <param name="info">해당하는 폴더 경로입니다.</param>
        /// <returns></returns>
        public static string[] GetAllFiles(this System.IO.DirectoryInfo info)
        {
            List<string> fileList = new List<string>();
            foreach (var i in info.GetAllDirs())
            {
                var fileInfo = new System.IO.DirectoryInfo(i);
                foreach (var j in fileInfo.GetFiles())
                    fileList.Add(j.FullName);
            }
            return fileList.ToArray();
        }

        /// <summary>
        /// 해당 디렉토리 내 모든 서브 디렉토리를 탐색하여 모든 디렉토리 경로를 반환합니다.
        /// </summary>
        /// <param name="info">해당하는 폴더 경로입니다.</param>
        /// <returns>모든 서브 디렉토리 FullName</returns>
        public static string[] GetAllDirs(this System.IO.DirectoryInfo info)
        {
            List<string> dirList = new List<string>();
            foreach (var filePath in info.Parent.GetDirectories())
            {
                ListAddDirs(dirList, filePath.FullName);
            }
            return dirList.ToArray();
        }
    }
}
