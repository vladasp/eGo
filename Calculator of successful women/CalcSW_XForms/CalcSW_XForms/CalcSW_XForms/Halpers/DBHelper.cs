using CalcSW_XForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;

namespace CalcSW_XForms.Halpers
{
    public class DBHelper
    {
        SQLiteConnection _connection;
        object _locker = new object();
        private DBHelper()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<ResultModel>();
        }

        public List<ResultModel> ResultModels
        {
            get
            {
                return _connection.Table<ResultModel>().ToList();
            }
        }

        static Lazy<DBHelper> _instance = new Lazy<DBHelper>(() => new DBHelper());

        public static DBHelper Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void AddResult(ResultModel result)
        {
            _connection.Insert(result);
        }

        public ResultModel Selected(ResultModel result)
        {
            return _connection.Table<ResultModel>().Where(item =>
                item.Name == result.Name &&
                item.Age == result.Age &&
                item.Kids == result.Kids &&
                item.Girls == result.Girls &&
                item.Boys == result.Boys &&
                item.Dogs == result.Dogs &&
                item.Cats == result.Cats &&
                item.Career == result.Career &&
                item.Family == result.Family &&
                item.Yourself == result.Yourself
                ).FirstOrDefault();
        }

        public void Update(ResultModel result)
        {
            lock (_locker)
            {
                try
                {
                    var res = _connection.Table<ResultModel>().Where(item =>
                    item.Name == BufferData.CurrentResult.Name &&
                    item.Age == BufferData.CurrentResult.Age &&
                    item.Kids == BufferData.CurrentResult.Kids &&
                    item.Girls == BufferData.CurrentResult.Girls &&
                    item.Boys == BufferData.CurrentResult.Boys &&
                    item.Dogs == BufferData.CurrentResult.Dogs &&
                    item.Cats == BufferData.CurrentResult.Cats &&
                    item.Career == BufferData.CurrentResult.Career &&
                    item.Family == BufferData.CurrentResult.Family &&
                    item.Yourself == BufferData.CurrentResult.Yourself
                    ).FirstOrDefault();

                    res.Name = result.Name;
                    res.Age = result.Age;
                    res.Kids = result.Kids;
                    res.Girls = result.Girls;
                    res.Boys = result.Boys;
                    res.Dogs = result.Dogs;
                    res.Cats = result.Cats;
                    res.Career = result.Career;
                    res.Family = result.Family;
                    res.Yourself = result.Yourself;
                    res.Answer = result.Answer;

                    _connection.Update(res);
                }
                catch (Exception ex)
                {
                    string exc = ex.Message;
                }
            }
        }


    }
}
