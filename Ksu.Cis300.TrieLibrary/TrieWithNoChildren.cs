using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _emptyString = false;

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyString = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                int loc = s[0] - 'a';
                if (_children[loc] == null)
                {
                    _children[loc] = new TrieWithOneChild();
                }
                _children[loc] = _children[loc].Add(s.Substring(1));
            }
            return this;
        }
    

        public bool Contains(string s)
        {   
            if (s == "")
            {
                return _emptyString;
            }
            else
            {
                return false;
            }

        }
    }
}
