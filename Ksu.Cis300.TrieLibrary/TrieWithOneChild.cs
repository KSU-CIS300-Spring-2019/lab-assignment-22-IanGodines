using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        private bool _emptyString = false;

        private ITrie[] _onlychild = new ITrie[26];

        private char _label;

        public TrieWithOneChild(string s, bool x)
        {
            if (s == "" || s[0] > 'z' || s[0] < 'a')
            {
                throw new Exception();
            }
        }
 
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyString = true;
            }
            else if (s[0] == _label)
            {
                _onlychild[s[0] - 'a'].Add(s.Substring(1));
                return this;
            }
            else
            {
                _onlychild[s[0] - 'a'] = new TrieWithManyChildren(s,_emptyString,_label,_children);
            }
        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                return _emptyString;
            }
            else
            {
                int loc = s[0] - 'a';
                if (s[0] == _label)
                {
                    return _onlychild[loc].Contains(s.Substring(1)); ;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
