using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Blockchain
{
    public class Block<T>where T: class
    {
        public Block(T data,Block<T> block=null)
        {
            Data = data;
            DataJson = JsonSerializer(data);
            Hash = CalculateHash(DataJson);
            TimeStamp = DateTime.Now;
            if (block == null)
            {
                PrevHash = null;
            }
            else
            {
                PrevHash = CalculateHash(block.DataJson);

            }
        }

        public long Index { get; set; }
        public DateTime TimeStamp { get; private set; }
        public string Hash { get; set; }
        public string PrevHash { get; set; } 
        public T Data { private set; get; }
        public string DataJson {private set; get; }
        public string Author { set; get; }
        
        public T GetData()
        {
            return JsonDeserialize(DataJson); ;
        }

        protected virtual string CalculateHash(string data)
        {
            return data.GetHashCode().ToString();
        }


        public static string JsonSerializer(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public static T JsonDeserialize(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }

    }
}
