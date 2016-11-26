using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_tracker
{
    public class DataCollectionStructure
    {

        public String data;
        public int counter;

        public DataCollectionStructure(String data, int counter)
        {
            this.data = data;
            this.counter = counter;
        }

        override
        public String ToString()
        {
            return data + " -> " + counter + "\r\n";
        }
    }
}
