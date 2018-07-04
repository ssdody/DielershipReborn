using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace DealershipLibrary
{
    [Serializable]
    public class Dealer
    {
        public List<Car> CarsList { get; set; }


        public Dealer()
        {
            CarsList = new List<Car>();
        }
        
        
    }
    
    
}
