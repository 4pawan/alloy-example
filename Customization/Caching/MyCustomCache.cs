using Microsoft.AspNetCore.OutputCaching;
using System;

namespace alloy_example.Customization.Caching;

public class MyCustomCache : IOutputCachePolicy
{
    public ValueTask CacheRequestAsync(OutputCacheContext context, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public ValueTask ServeFromCacheAsync(OutputCacheContext context, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public ValueTask ServeResponseAsync(OutputCacheContext context, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}

