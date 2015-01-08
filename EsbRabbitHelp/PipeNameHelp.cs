using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbRabbitHelp
{
    public enum PipeName
    {
        EsbUpdateOrAddMockData,
        EsbRequestInfoIn,
        EsbRequestInfoOut,
        EsbNewData,
        EsbEditData,
        EsbGetMockData,
        rpc_getByRequest,
        rpc_getByComment,
        rpc_get_all,
        rpc_delete
    }
}
