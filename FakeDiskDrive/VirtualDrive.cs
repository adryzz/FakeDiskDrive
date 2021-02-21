using DokanNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FakeDiskDrive
{
    public class VirtualDrive : IDokanOperations
    {
        public string DriveLetter = "";
        public string FileSystem = "";
        public string Label = "";
        public long FreeBytesAvailable = 0;
        public long TotalNumberOfBytes = 0;
        public long TotalNumberOfFreeBytes = 0;
        public DokanOptions Options;

        public VirtualDrive(string letter, string fs, string label, long freeBytesAvailable, long totalNumberOfBytes, long totalNumberOfFreeBytes, DokanOptions options)
        {
            DriveLetter = letter;
            FileSystem = fs;
            Label = label;
            FreeBytesAvailable = freeBytesAvailable;
            TotalNumberOfBytes = totalNumberOfBytes;
            TotalNumberOfFreeBytes = totalNumberOfFreeBytes;
            Options = options;
        }

        public void Cleanup(string fileName, IDokanFileInfo info)
        {
            
        }

        public void CloseFile(string fileName, IDokanFileInfo info)
        {
            
        }

        public NtStatus CreateFile(string fileName, DokanNet.FileAccess access, FileShare share, FileMode mode, FileOptions options, FileAttributes attributes, IDokanFileInfo info)
        {
            return DokanResult.Success;
        }

        public NtStatus DeleteDirectory(string fileName, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus DeleteFile(string fileName, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus FindFiles(string fileName, out IList<FileInformation> files, IDokanFileInfo info)
        {
            files = null;
            return DokanResult.Error;
        }

        public NtStatus FindFilesWithPattern(string fileName, string searchPattern, out IList<FileInformation> files, IDokanFileInfo info)
        {
            files = null;
            return DokanResult.Error;
        }

        public NtStatus FindStreams(string fileName, out IList<FileInformation> streams, IDokanFileInfo info)
        {
            streams = null;
            return DokanResult.Error;
        }

        public NtStatus FlushFileBuffers(string fileName, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus GetDiskFreeSpace(out long freeBytesAvailable, out long totalNumberOfBytes, out long totalNumberOfFreeBytes, IDokanFileInfo info)
        {
            freeBytesAvailable = FreeBytesAvailable;
            totalNumberOfBytes = TotalNumberOfBytes;
            totalNumberOfFreeBytes = TotalNumberOfFreeBytes;
            return DokanResult.Success;
        }

        public NtStatus GetFileInformation(string fileName, out FileInformation fileInfo, IDokanFileInfo info)
        {
            fileInfo = new FileInformation();
            return DokanResult.Error;
        }

        public NtStatus GetFileSecurity(string fileName, out FileSystemSecurity security, AccessControlSections sections, IDokanFileInfo info)
        {
            security = null;
            return DokanResult.Error;
        }

        public NtStatus GetVolumeInformation(out string volumeLabel, out FileSystemFeatures features, out string fileSystemName, out uint maximumComponentLength, IDokanFileInfo info)
        {
            volumeLabel = Label;
            features = FileSystemFeatures.None;
            fileSystemName = FileSystem;
            maximumComponentLength = 256;
            return DokanResult.Success;
        }

        public NtStatus LockFile(string fileName, long offset, long length, IDokanFileInfo info)
        {
            throw new NotImplementedException();
        }

        public NtStatus Mounted(IDokanFileInfo info)
        {
            return DokanResult.Success;
        }

        public NtStatus MoveFile(string oldName, string newName, bool replace, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus ReadFile(string fileName, byte[] buffer, out int bytesRead, long offset, IDokanFileInfo info)
        {
            bytesRead = 0;
            return DokanResult.Error;
        }

        public NtStatus SetAllocationSize(string fileName, long length, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus SetEndOfFile(string fileName, long length, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus SetFileAttributes(string fileName, FileAttributes attributes, IDokanFileInfo info)
        {
             return DokanResult.Error;
        }

        public NtStatus SetFileSecurity(string fileName, FileSystemSecurity security, AccessControlSections sections, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus SetFileTime(string fileName, DateTime? creationTime, DateTime? lastAccessTime, DateTime? lastWriteTime, IDokanFileInfo info)
        {
            return DokanResult.Error;
        }

        public NtStatus UnlockFile(string fileName, long offset, long length, IDokanFileInfo info)
        {
            return DokanResult.Success;
        }

        public NtStatus Unmounted(IDokanFileInfo info)
        {
            return DokanResult.Success;
        }

        public NtStatus WriteFile(string fileName, byte[] buffer, out int bytesWritten, long offset, IDokanFileInfo info)
        {
            bytesWritten = 0;
            return DokanResult.Error;
        }
    }
}
