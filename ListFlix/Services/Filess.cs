using ListFlix.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFlix.Services
{
    internal class Filess
    {


        private readonly string PATH; 



       public Filess(string path)
        {
            PATH = path;
        }


        public BindingList<TodoModel> LoadDate()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.Create(PATH).Dispose();
                return new BindingList<TodoModel>();
            }

            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }
           
        }


        public void SaveDate(object todoDataList)
        {
            using  (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }




    }
}
