using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Week_04.Droid;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseService))]
namespace Week_04.Droid
{
    public class DatabaseService : IDBInterface
    {
        public SQLiteConnection CreateConnection()
        {

            var sqliteFilename = "MovieDB.db";
            string documentsDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            return new SQLiteConnection(path, false);
        }
        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            byte[] buffer = new byte[Length];
            int byteRead = readStream.Read(buffer, 0, Length);
            while (byteRead >= 0)
            {
                writeStream.Write(buffer, 0, byteRead);
                byteRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}