using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Java.IO;
using System.Diagnostics;
using MVVMCalc.Services;

namespace MVVMCalc
{
    public class DataBaseHelper: IDataBaseHelper
    {
        SQLiteConnection _connection;
        public ResultModel Current;
        public bool IsClear;

        DataBaseHelper()
        {
            Android.OS.Environment.DataDirectory.SetWritable(true);
            string path = Android.OS.Environment.DataDirectory.Path;
            try
            {
                _connection = new SQLiteConnection(Path.Combine(path, "CalcDB"));
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            _connection.CreateTable<ResultModel>();
        }

        static Lazy<DataBaseHelper> instance = new Lazy<DataBaseHelper>(() => new DataBaseHelper());

        public static DataBaseHelper Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public List<ResultModel> GetResults()
        {
            return _connection.Table<ResultModel>().ToList();
        }

        public void AddResult(ResultModel result)
        {
            _connection.Insert(result);
        }

        public void Update(int position, ResultModel result)
        {
            var item = _connection.Get<ResultModel>(result);
            item = result;
            _connection.Update(item);
        }

        public void Selected(int position)
        {
            Current = _connection.Get<ResultModel>(position);
        }

    }
}
