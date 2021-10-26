using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoAppMastek.Models
{
    public interface ITransientService
    {
        Guid GetOperationID();
    }
    public interface IScopedService
    {
        Guid GetOperationID();
    }
    public interface ISingletonService
    {
        Guid GetOperationID();
    }
    public class OperationService : ITransientService, IScopedService, ISingletonService
    {
        Guid id;
        public OperationService()
        {
            id = Guid.NewGuid(); //new GUID object
        }
        public Guid GetOperationID()
        {
            return id;
        }
    }
}
