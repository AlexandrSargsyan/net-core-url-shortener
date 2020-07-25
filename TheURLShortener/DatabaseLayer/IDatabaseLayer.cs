using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheURLShortener.Models;

namespace TheURLShortener.DatabaseLayer
{
    public interface IDatabase
    {
        int Insert(URLEntity uRLEntity);
        string GetUrl(string alias);
    }
}