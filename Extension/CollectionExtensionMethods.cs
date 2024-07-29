using System.Collections.Concurrent;

namespace Utilities.Helpers.Extensions.Extension;

public static class CollectionExtensionMethods
{
    public static Task ParallelForEachAsync<T>(this ICollection<T> source, int dop, Func<T, Task> body)
    {
        async Task AwaitPartition(IEnumerator<T> partition)
        {
            using (partition)
            {
                while (partition.MoveNext())
                { await body(partition.Current); }
            }
        }
        return Task.WhenAll(
            Partitioner
                .Create(source)
                .GetPartitions(dop)
                .AsParallel()
                .Select(AwaitPartition));
    }

    public static bool RemoveFirst<T>(this ICollection<T> source, Func<T, bool> body)
    {
        var removed = source.FirstOrDefault(s => body(s));
        if (removed == null)
            return false;
        source.Remove(removed);

        return true;
    }

    public static void VoidSelect<T>(this ICollection<T> source, Action<T> func)
    {
        foreach (var element in source)
        {
            func(element);
        }
    }


}
