using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityNotifier.DataContract
{
    public class RootObject1<T> where T : ObjectBase
    {
        public int Count { get; set; }
        public string Href { get; set; }
        public List<T> Items { get; set; }
    }
}
