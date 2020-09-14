using KVKApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KVKApp.Services.Api
{
    public interface IApiService
    {
        Task<IEnumerable<Company>> Sync();
    }
}
