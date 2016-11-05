using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class CardGameObject
    {
        public Dictionary<string, object> KeyList;
        public Game ParentGame
        {
            get { return GamePlatform.ActiveGame; }
        }
        public Dictionary<string, object> CloneKeyList()
        {
            return (from x in this.KeyList select x).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
