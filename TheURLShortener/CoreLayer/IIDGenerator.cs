using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheURLShortener.CoreLayer
{
    public interface IIDGenerator
    {
        string Generate(int length);
    }
}

