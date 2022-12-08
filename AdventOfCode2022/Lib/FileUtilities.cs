using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class FileUtilities
    {
        public static async Task<string> GetSampleAsync(string filename)
        {
            return await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "Inputs", filename));
        }
    }
}
