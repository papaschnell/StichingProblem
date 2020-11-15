using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Client
{
    public interface ITestClient
    {
        Task<IOperationResult<IGetValues>> GetValuesAsync();

        Task<IOperationResult<IGetValues>> GetValuesAsync(
            CancellationToken cancellationToken);
    }
}
