namespace MinimalAPI;

public static class ApiConstants
{
    private const string ApiBaseUrl = "/api";

    // [new] Constant interpolated strings
    public const string Storage = $"{ApiBaseUrl}/storage";

    public const string StorageStream = $"{Storage}-stream";
}