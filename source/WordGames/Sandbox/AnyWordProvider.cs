﻿namespace Sandbox
{
    class AnyWordProvider : IWordProvider
    {
        public bool Contains(string word)
        {
            return true;
        }

        public bool StartsWith(string prefix)
        {
            return true;
        }
    }
}
