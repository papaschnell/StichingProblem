using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace Client
{
    public class TestClient
        : ITestClient
    {
        private readonly IOperationExecutor _executor;

        public TestClient(IOperationExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public Task<IOperationResult<IGetValues>> GetValuesAsync() =>
            GetValuesAsync(CancellationToken.None);

        public Task<IOperationResult<IGetValues>> GetValuesAsync(
            CancellationToken cancellationToken)
        {

            return _executor.ExecuteAsync(
                new GetValuesOperation(),
                cancellationToken);
        }
    }
}
