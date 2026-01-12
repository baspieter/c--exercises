public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long value)
    {
        // Internal buffer is always 9 bytes: 1 prefix + up to 8 payload bytes
        var buffer = new byte[9];

        byte[] payload;
        byte prefix;

        if (value >= 0)
        {
            if (value <= ushort.MaxValue)
            {
                // ushort (2 bytes), unsigned => prefix = 2
                payload = GetLittleEndianBytes((ushort)value);
                prefix = 2;
            }
            else if (value <= int.MaxValue)
            {
                // int (4 bytes), signed => prefix = 256 - 4 = 252 (0xFC)
                payload = GetLittleEndianBytes((int)value);
                prefix = (byte)(256 - 4);
            }
            else if (value <= uint.MaxValue)
            {
                // uint (4 bytes), unsigned => prefix = 4
                payload = GetLittleEndianBytes((uint)value);
                prefix = 4;
            }
            else
            {
                // long (8 bytes), signed => prefix = 256 - 8 = 248 (0xF8)
                payload = GetLittleEndianBytes(value);
                prefix = (byte)(256 - 8);
            }
        }
        else
        {
            if (value >= short.MinValue)
            {
                // short (2 bytes), signed => prefix = 256 - 2 = 254 (0xFE)
                payload = GetLittleEndianBytes((short)value);
                prefix = (byte)(256 - 2);
            }
            else if (value >= int.MinValue)
            {
                // int (4 bytes), signed => prefix = 256 - 4 = 252 (0xFC)
                payload = GetLittleEndianBytes((int)value);
                prefix = (byte)(256 - 4);
            }
            else
            {
                // long (8 bytes), signed => prefix = 256 - 8 = 248 (0xF8)
                payload = GetLittleEndianBytes(value);
                prefix = (byte)(256 - 8);
            }
        }

        buffer[0] = prefix;

        // Copy payload right after prefix
        Array.Copy(payload, 0, buffer, 1, payload.Length);

        // Remaining bytes stay 0x00 automatically
        return buffer;
    }

    private static byte[] GetLittleEndianBytes(short v)  => EnsureLittleEndian(BitConverter.GetBytes(v));
    private static byte[] GetLittleEndianBytes(ushort v) => EnsureLittleEndian(BitConverter.GetBytes(v));
    private static byte[] GetLittleEndianBytes(int v)    => EnsureLittleEndian(BitConverter.GetBytes(v));
    private static byte[] GetLittleEndianBytes(uint v)   => EnsureLittleEndian(BitConverter.GetBytes(v));
    private static byte[] GetLittleEndianBytes(long v)   => EnsureLittleEndian(BitConverter.GetBytes(v));

    private static byte[] EnsureLittleEndian(byte[] bytes)
    {
        if (!BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        return bytes;
    }

public static long FromBuffer(byte[] buffer)
{
    if (buffer is null || buffer.Length != 9)
        throw new ArgumentException("Telemetry buffer must be 9 bytes.");

    byte prefix = buffer[0];

    bool isSigned = prefix >= 128;
    int byteCount = isSigned ? 256 - prefix : prefix;

    // Only 2/4/8 bytes are valid in this protocol
    if (byteCount != 2 && byteCount != 4 && byteCount != 8)
        return 0;

    // Also must fit in the provided buffer (prefix + payload)
    if (1 + byteCount > buffer.Length)
        return 0;

    var payload = new byte[byteCount];
    Array.Copy(buffer, 1, payload, 0, byteCount);

    if (!BitConverter.IsLittleEndian)
        Array.Reverse(payload);

    return (byteCount, isSigned) switch
    {
        (2, false) => BitConverter.ToUInt16(payload, 0),
        (4, false) => BitConverter.ToUInt32(payload, 0),
        (8, false) => (long)BitConverter.ToUInt64(payload, 0),

        (2, true)  => BitConverter.ToInt16(payload, 0),
        (4, true)  => BitConverter.ToInt32(payload, 0),
        (8, true)  => BitConverter.ToInt64(payload, 0),

        _ => 0
    };
}
}
