using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Blockchain
{
    public class Pool<T> where T:class
    {
        
        private static Pool<T> instance; 
        public static Pool<T> Instance()
        {
            if (instance == null)
                instance = new Pool<T>();
            return instance;

        }

        private List<Block<T>> blocksList = new List<Blockchain.Block<T>>();
        
        public void AddBlock(T obj,string author="No Author")
        {
            Block<T> block;
            if (blocksList.Count==0)
            {
                block = new Block<T>(obj);
            }
            else
            {
                block = new Block<T>(obj, blocksList[blocksList.Count-1]); 
            }
            block.Author = author;
            block.Index = blocksList.Count;
            blocksList.Add(block);
        }

        public ObservableCollection<Block<T>> GetList()
        {
            return new ObservableCollection<Block<T>>(blocksList); ;
        }

        public void LoadDataFromFile()
        {

        }

        public void SaveDataToFile()
        {

        }


    }
}
