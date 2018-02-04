using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace DielershipLibrary
{
    [Serializable]
    public class Dieler
    {
        public List<Car> CarsList { get; set; }


        public Dieler()
        {
            CarsList = new List<Car>();
        }
        
        
    }
    
    
}
