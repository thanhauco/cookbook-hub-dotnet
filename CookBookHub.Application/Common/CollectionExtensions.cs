namespace CookBookHub.Application.Common;

public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? collection)
    {
        return collection == null || !collection.Any();
    }

    public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T>? collection)
    {
        return collection ?? Enumerable.Empty<T>();
    }

    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
    {
        T[]? bucket = null;
        var count = 0;

        foreach (var item in source)
        {
            bucket ??= new T[size];
            bucket[count++] = item;

            if (count != size)
                continue;

            yield return bucket.Select(x => x);

            bucket = null;
            count = 0;
        }

        if (bucket != null && count > 0)
        {
            Array.Resize(ref bucket, count);
            yield return bucket.Select(x => x);
        }
    }
}
