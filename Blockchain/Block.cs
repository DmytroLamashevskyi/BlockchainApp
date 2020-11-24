using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain
{
    public class Block<T>where T:class
    {
        public Block(T data,Block<T> block=null)
        {
            Data = JsonConvert.SerializeObject(data);
            Hash = CalculateHash(Data);
            TimeStamp = DateTime.Now;
            if (block == null)
            {
                PrevHash = null;
            }
            else
            {
                PrevHash = CalculateHash(block.Data);

            }
        }

        public long Index { get; set; }
        public DateTime TimeStamp { get; private set; }
        public string Hash { get; set; }
        public string PrevHash { get; set; } 
        public string Data {private set; get; }
        public string Author { set; get; }

        public T GetData()
        {
            return JsonConvert.DeserializeObject<T>(Data); ;
        }

        protected virtual string CalculateHash(string data)
        {
            return data.GetHashCode().ToString();
        }
    }
}
